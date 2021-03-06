﻿using MindSageWeb.Repositories;
using MindSageWeb.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MindSageWeb.Controllers
{
    public static class APIUtil
    {
        #region Methods

        public static bool CheckAccessPermissionToSelectedClassRoom(this IUserProfileRepository userprofileRepo, string userprofileId, string classRoomId)
        {
            UserProfile userprofile;
            return CheckAccessPermissionToSelectedClassRoom(userprofileRepo, userprofileId, classRoomId, out userprofile);
        }
        public static bool CheckAccessPermissionToSelectedClassRoom(this IUserProfileRepository userprofileRepo, string userprofileId, string classRoomId, out UserProfile userprofile)
        {
            userprofile = null;
            var areArgumentsValid = !string.IsNullOrEmpty(userprofileId) && !string.IsNullOrEmpty(classRoomId);
            if (!areArgumentsValid) return false;

            var selectedUserProfile = userprofileRepo.GetUserProfileById(userprofileId);
            if (selectedUserProfile == null) return false;
            userprofile = selectedUserProfile;

            var canAccessToTheClass = selectedUserProfile
                .Subscriptions
                .Where(it => !it.DeletedDate.HasValue && it.ClassRoomId.Equals(classRoomId, StringComparison.CurrentCultureIgnoreCase))
                .Any();

            return canAccessToTheClass;
        }
        public static bool CheckAccessPermissionToSelectedClassLesson(this IClassCalendarRepository classCalendarRepo, string classRoomId, string lessonId, DateTime currentTime, bool isTeacher = false)
        {
            var areArgumentsValid = !string.IsNullOrEmpty(classRoomId) && !string.IsNullOrEmpty(lessonId);
            if (!areArgumentsValid) return false;

            var selectedClassCalendar = classCalendarRepo.GetClassCalendarByClassRoomId(classRoomId);
            var isClassCalendarValid = selectedClassCalendar != null && !selectedClassCalendar.DeletedDate.HasValue;
            if (!isClassCalendarValid) return false;

            var canAccessToTheLesson = selectedClassCalendar.LessonCalendars
                .Where(it => !it.DeletedDate.HasValue)
                .Where(it => it.LessonId.Equals(lessonId, StringComparison.CurrentCultureIgnoreCase))
                .Where(it => isTeacher || it.BeginDate <= currentTime)
                .Any();
            return canAccessToTheLesson;
        }
        public static bool CheckAccessPermissionToUserProfile(this IUserProfileRepository userprofileRepo, string userprofileId)
        {
            var selectedCommentOwnerProfile = userprofileRepo.GetUserProfileById(userprofileId);
            var canPostNewDiscussion = selectedCommentOwnerProfile != null
                && !selectedCommentOwnerProfile.IsPrivateAccount;
            return canPostNewDiscussion;
        }


        public static IEnumerable<string> GetAllUserCoursCatalogIds(this MyCourseController ctrl, string userprofileId)
        {
            var qry = ctrl.GetAllCourses(userprofileId).Select(it => it.CourseCatalogId);
            return qry;
        }
        public static bool CanAddNewCourseCatalog(this MyCourseController ctrl, string userprofileId, string courseCatalogId, out IEnumerable<string> allUserCourseCatalogIds)
        {
            allUserCourseCatalogIds = ctrl.GetAllUserCoursCatalogIds(userprofileId);
            var result = !allUserCourseCatalogIds.Contains(courseCatalogId);
            return result;
        }
        public static bool CanAddNewCourseCatalog(this MyCourseController ctrl, string userprofileId, string courseCatalogId)
        {
            var allUserCourseCatalogIds = Enumerable.Empty<string>();
            return ctrl.CanAddNewCourseCatalog(userprofileId, courseCatalogId, out allUserCourseCatalogIds);
        }

        public static void CalculateCourseSchedule(this ClassCalendar classCalendar)
        {
            var areArgumentsValid = classCalendar != null
                && classCalendar.BeginDate.HasValue
                && classCalendar.LessonCalendars != null
                && classCalendar.LessonCalendars.Any();
            if (!areArgumentsValid) return;

            classCalendar.Holidays = classCalendar.Holidays ?? Enumerable.Empty<DateTime>();
            classCalendar.ShiftDays = classCalendar.ShiftDays ?? Enumerable.Empty<DateTime>();

            const int ShiftOneDay = 1;
            const int LessonDuration = 5;
            var currentBeginDate = classCalendar.BeginDate.Value.ToUniversalTime();
            var shiftDays = (classCalendar.ShiftDays ?? Enumerable.Empty<DateTime>()).Select(it => it.ToUniversalTime());
            var lessonQry = classCalendar.LessonCalendars.Where(it => !it.DeletedDate.HasValue).OrderBy(it => it.Order);
            foreach (var lesson in lessonQry)
            {
                // Set begin date for each lesson
                var list = new List<DateTime>();
                var beginDateOfferDay = 0;
                while (list.Count < LessonDuration)
                {
                    var date = currentBeginDate.AddDays(beginDateOfferDay++);
                    if (!shiftDays.Any(it => it == date)) list.Add(date);
                }
                lesson.BeginDate = list.First();
                currentBeginDate = list.Last().AddDays(ShiftOneDay);

                // Set topic of the day date
                foreach (var totd in lesson.TopicOfTheDays)
                {
                    var sendDay = totd.SendOnDay - ShiftOneDay;
                    totd.RequiredSendTopicOfTheDayDate = lesson.BeginDate.AddDays(sendDay);
                }
            }
            classCalendar.ExpiredDate = currentBeginDate.AddDays(-1);
        }

        public static UserActivity CreateNewUserActivity(this UserProfile selectedUserProfile, ClassRoom selectedClassRoom, ClassCalendar selectedClassCalendar, List<LessonCatalog> lessonCatalogs, DateTime now)
        {
            var lessonActivities = selectedClassRoom.Lessons.Select(lessonInClassRoom =>
            {
                var selectedLessonCalendar = selectedClassCalendar.LessonCalendars
                    .Where(it => !it.DeletedDate.HasValue)
                    .FirstOrDefault(lessonCalendar => lessonCalendar.LessonId == lessonInClassRoom.id);

                var selectedLessonCatalog = lessonCatalogs.FirstOrDefault(it => it.id == lessonInClassRoom.LessonCatalogId);

                var totalContentsAmount = selectedLessonCatalog.PostAssessments.Count()
                    + selectedLessonCatalog.PreAssessments.Count()
                    + selectedLessonCatalog.StudentItems.Count()
                    + selectedLessonCatalog.TeacherItems.Count();
                return new UserActivity.LessonActivity
                {
                    id = Guid.NewGuid().ToString(),
                    BeginDate = selectedLessonCalendar.BeginDate,
                    TotalContentsAmount = totalContentsAmount,
                    LessonId = lessonInClassRoom.id,
                    SawContentIds = Enumerable.Empty<string>()
                };
            }).ToList();

            var userActivity = new UserActivity
            {
                id = Guid.NewGuid().ToString(),
                UserProfileName = selectedUserProfile.Name,
                UserProfileImageUrl = selectedUserProfile.ImageProfileUrl,
                UserProfileId = selectedUserProfile.id,
                ClassRoomId = selectedClassRoom.id,
                CreatedDate = now,
                LessonActivities = lessonActivities
            };

            return userActivity;
        }

        public static string CreateAddressSummary(string address, string state, string city, string country, string zipCode)
        {
            var areArgumentValid = !string.IsNullOrEmpty(address)
                    && !string.IsNullOrEmpty(state)
                    && !string.IsNullOrEmpty(city)
                    && !string.IsNullOrEmpty(country)
                    && !string.IsNullOrEmpty(zipCode);
            if (!areArgumentValid) return string.Empty;
            return string.Format($"{address} {state} {city} {country} {zipCode}");
        }

        public static string GetLast4Characters(string data)
        {
            if (string.IsNullOrEmpty(data)) return string.Empty;
            const int MinimumDigitRequired = 4;
            if (data.Length < MinimumDigitRequired) return string.Empty;
            var beginIndex = data.Length - MinimumDigitRequired;
            return data.Substring(beginIndex, MinimumDigitRequired);
        }

        public static string EncodeCreditCard(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber)) return string.Empty;
            const int MinimumDigitRequired = 8;
            if (cardNumber.Length < MinimumDigitRequired) return string.Empty;
            var beginIndex = cardNumber.Length - MinimumDigitRequired;
            const string ReplaceNumberKey = "xxxx";
            var originalNumber = cardNumber.Substring(beginIndex, ReplaceNumberKey.Length);
            var result = cardNumber.Replace(originalNumber, ReplaceNumberKey);
            return result;
        }

        #endregion Methods
    }
}
