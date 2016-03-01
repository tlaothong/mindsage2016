module app.lessons {
    'use strict';

    class LessonController {

        public teacherView: boolean;
        public currentUser: any;
        public message: string;
        public discussions = [];
        private requestedCommentIds = [];

        static $inject = ['$scope', 'content', 'classRoomId', 'lessonId', 'comment', 'likes', 'app.shared.ClientUserProfileService', 'app.shared.DiscussionService', 'app.shared.CommentService', 'app.lessons.LessonService'];
        constructor(private $scope, public content, public classRoomId: string, public lessonId: string, public comment, public likes, private userprofileSvc: app.shared.ClientUserProfileService, private discussionSvc: app.shared.DiscussionService, private commentSvc: app.shared.CommentService, private lessonSvc: app.lessons.LessonService) {
            this.teacherView = false;
            this.currentUser = this.userprofileSvc.GetClientUserProfile();
            this.userprofileSvc.Advertisments = this.content.Advertisments;
        }

        public selectTeacherView(): void {
            this.teacherView = true;
        }

        public selectStdView(): void {
            this.teacherView = false;
        }

        public showDiscussion(item: any, open: boolean) {
            this.GetDiscussions(item);
            return !open;
        }

        public GetDiscussions(comment) {
            if (comment == null) return;

            const NoneDiscussion = 0;
            if (comment.TotalDiscussions <= NoneDiscussion) return;
            if (this.requestedCommentIds.filter(it=> it == comment.id).length > NoneDiscussion) return;

            this.requestedCommentIds.push(comment.id);
            this.discussionSvc
                .GetDiscussions(this.lessonId, this.classRoomId, comment.id)
                .then(it=> {
                    if (it == null) return;
                    for (var index = 0; index < it.length; index++) {
                        this.discussions.push(it[index]);
                    }
                });
        }

        public CreateNewComment(message: string) {
            const NoneContentLength = 0;
            if (message.length <= NoneContentLength) return;

            var userprofile = this.userprofileSvc.GetClientUserProfile();
            var newComment = new app.shared.Comment('MOCK', message, 0, 0, userprofile.ImageUrl, userprofile.FullName, this.classRoomId, this.lessonId, userprofile.UserProfileId, 0 - this.comment.Comments.length);
            this.comment.Comments.push(newComment);
            this.commentSvc.CreateNewComment(this.classRoomId, this.lessonId, message)
                .then(it=> {
                    if (it == null) {
                        var removeIndex = this.comment.Comments.indexOf(newComment);
                        if (removeIndex > -1) this.comment.Comments.splice(removeIndex, 1);
                    }
                    else newComment.id = it.ActualCommentId;
                });
        }

        public CreateNewDiscussion(commentId: string, message: string) {
            const NoneContentLength = 0;
            if (message.length <= NoneContentLength) return;

            var userprofile = this.userprofileSvc.GetClientUserProfile();
            var newDiscussion = new app.shared.Discussion('DiscussionMOCK', commentId, message, 0, userprofile.ImageUrl, userprofile.FullName, userprofile.UserProfileId, 0 - this.discussions.length);
            this.discussions.push(newDiscussion);
            this.comment.Comments.filter(it=> it.id == commentId)[0].TotalDiscussions++;
            
            this.discussionSvc.CreateDiscussion(this.classRoomId, this.lessonId, commentId, message)
                .then(it=> {
                    if (it == null) {
                        var removeIndex = this.discussions.indexOf(newDiscussion);
                        if (removeIndex > -1) this.discussions.splice(removeIndex, 1);
                        this.comment.Comments.filter(it=> it.id == commentId)[0].TotalDiscussions--;
                    }
                    else newDiscussion.id = it.ActualCommentId;
                });
        }

        public LikeComment(commentId: string) {
            this.commentSvc.LikeComment(this.classRoomId, this.lessonId, commentId);

            var removeIndex = this.likes.LikeCommentIds.indexOf(commentId);
            const ElementNotFound = -1;
            if (removeIndex <= ElementNotFound) this.likes.LikeCommentIds.push(commentId);
            else this.likes.LikeCommentIds.splice(removeIndex, 1);
        }

        public LikeDiscussion(commentId: string, discussionId: string) {
            this.discussionSvc.LikeDiscussion(this.classRoomId, this.lessonId, commentId, discussionId);

            var removeIndex = this.likes.LikeDiscussionIds.indexOf(discussionId);
            const ElementNotFound = -1;
            if (removeIndex <= ElementNotFound) this.likes.LikeDiscussionIds.push(discussionId);
            else this.likes.LikeDiscussionIds.splice(removeIndex, 1);
        }

        public DeleteComment(comment: any) {
            var removeIndex = this.comment.Comments.indexOf(comment);
            if (removeIndex > -1) this.comment.Comments.splice(removeIndex, 1);
            this.commentSvc.UpdateComment(this.classRoomId, this.lessonId, comment.id, true, null);
        }

        public DeleteDiscussion(commentId: string, discussion: any) {
            var removeIndex = this.discussions.indexOf(discussion);
            if (removeIndex > -1) this.discussions.splice(removeIndex, 1);
            this.comment.Comments.filter(it=> it.id == commentId)[0].TotalDiscussions--;
            this.discussionSvc.UpdateDiscussion(this.classRoomId, this.lessonId, commentId, discussion.id, true, null);
        }

        public EditComment(commentId: string, message: string) {
            const NoneContentLength = 0;
            if (message.length <= NoneContentLength) return;

            this.commentSvc.UpdateComment(this.classRoomId, this.lessonId, commentId, false, message);
        }

        public EditDiscussion(commentId: string, discussionId: string, message: string) {
            const NoneContentLength = 0;
            if (message.length <= NoneContentLength) return;

            this.discussionSvc.UpdateDiscussion(this.classRoomId, this.lessonId, commentId, discussionId, false, message);
        }

        public LikeLesson() {
            this.likes.IsLikedLesson = !this.likes.IsLikedLesson;
            this.lessonSvc.LikeLesson(this.classRoomId, this.lessonId);
        }

        public ReadNote() {
            this.lessonSvc.ReadNote(this.classRoomId);
        }

        public EditOpen(message: string, open: boolean) {
            this.message = message;
            return !open;
        }

        public SaveEdit(messageId: number, save: boolean) {
            this.comment.Comments.filter(it=> it.id == messageId)[0].Description = this.message;
            this.EditComment(this.comment.Comments.filter(it=> it.id == messageId)[0].id, this.message);
            return !save;
        }

        public SaveEditDiscus(commentId: string, messageId: number, save: boolean) {

            this.discussions.filter(it=> it.id == messageId)[0].Description = this.message;
            this.EditDiscussion(commentId, this.discussions.filter(it=> it.id == messageId)[0].id, this.message);
            return !save;
        }

        public CancelEdit(save: boolean) {
            return !save;
        }

    } 

    angular
        .module('app.lessons')
        .controller('app.lessons.LessonController', LessonController);
}