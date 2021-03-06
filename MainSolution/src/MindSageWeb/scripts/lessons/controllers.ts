module app.lessons {
    'use strict';

    class LessonController {

        public teacherView: boolean;
        public currentUser: any;
        public message: string;
        public targetComment: any;
        public targetDiscussion: any;
        public deleteComment: boolean;
        public discussions = [];
        private requestedCommentIds = [];
        private likes: any;

        static $inject = ['$scope', 'content', 'classRoomId', 'lessonId', 'comment', 'app.shared.ClientUserProfileService', 'app.shared.DiscussionService', 'app.shared.CommentService', 'app.lessons.LessonService', 'app.shared.GetProfileService'];
        constructor(private $scope, public content, public classRoomId: string, public lessonId: string, public comment, private userprofileSvc: app.shared.ClientUserProfileService, private discussionSvc: app.shared.DiscussionService, private commentSvc: app.shared.CommentService, private lessonSvc: app.lessons.LessonService, private getProfileSvc: app.shared.GetProfileService) {
            this.teacherView = false;
            this.currentUser = this.userprofileSvc.GetClientUserProfile();
            this.currentUser.CurrentDisplayLessonId = lessonId;
            this.userprofileSvc.UpdateUserProfile(this.currentUser);
            this.userprofileSvc.Advertisments = this.content.Advertisments;
            this.getProfileSvc.GetLike().then(it=> this.likes = it);
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
            if (message.length <= NoneContentLength) return message;

            this.commentSvc.CreateNewComment(this.classRoomId, this.lessonId, message)
                .then(it=> {
                    if (it == null) {
                        return message;
                    }
                    else {
                        var userprofile = this.userprofileSvc.GetClientUserProfile();
                        var newComment = new app.shared.Comment(it.ActualCommentId, message, 0, 0, userprofile.ImageUrl, userprofile.FullName, this.classRoomId, this.lessonId, userprofile.UserProfileId, 0 - this.comment.Comments.length);
                        this.comment.Comments.push(newComment);
                        return "";
                    }
                });
        }

        public CreateNewDiscussion(commentId: string, message: string) {
            const NoneContentLength = 0;
            if (message.length <= NoneContentLength) return message;

            this.discussionSvc.CreateDiscussion(this.classRoomId, this.lessonId, commentId, message)
                .then(it=> {
                    if (it == null) {
                        return message;
                    }
                    else {
                        var userprofile = this.userprofileSvc.GetClientUserProfile();
                        var newDiscussion = new app.shared.Discussion(it.ActualCommentId, commentId, message, 0, userprofile.ImageUrl, userprofile.FullName, userprofile.UserProfileId, 0 - this.discussions.length);
                        this.discussions.push(newDiscussion);
                        this.comment.Comments.filter(it=> it.id == commentId)[0].TotalDiscussions++;
                        return "";
                    }
                });
        }

        public LikeComment(commentId: string, IsLike: number) {
            if (IsLike == -1)
                this.comment.Comments.filter(it=> it.id == commentId)[0].TotalLikes++;
            else
                this.comment.Comments.filter(it=> it.id == commentId)[0].TotalLikes--;

            this.commentSvc.LikeComment(this.classRoomId, this.lessonId, commentId);

            var removeIndex = this.likes.LikeCommentIds.indexOf(commentId);
            const ElementNotFound = -1;
            if (removeIndex <= ElementNotFound) this.likes.LikeCommentIds.push(commentId);
            else this.likes.LikeCommentIds.splice(removeIndex, 1);
        }

        public LikeDiscussion(commentId: string, discussionId: string, IsLike: number) {
            if (IsLike == -1)
                this.discussions.filter(it=> it.id == discussionId)[0].TotalLikes++;
            else
                this.discussions.filter(it=> it.id == discussionId)[0].TotalLikes--;

            this.discussionSvc.LikeDiscussion(this.classRoomId, this.lessonId, commentId, discussionId);

            var removeIndex = this.likes.LikeDiscussionIds.indexOf(discussionId);
            const ElementNotFound = -1;
            if (removeIndex <= ElementNotFound) this.likes.LikeDiscussionIds.push(discussionId);
            else this.likes.LikeDiscussionIds.splice(removeIndex, 1);
        }

        public DeleteComment() {
            var comment = this.targetComment;
            var removeIndex = this.comment.Comments.indexOf(comment);
            if (removeIndex > -1) this.comment.Comments.splice(removeIndex, 1);
            this.commentSvc.UpdateComment(this.classRoomId, this.lessonId, comment.id, true, null);
        }

        public DeleteDiscussion() {
            var commentId = this.targetComment.id;
            var discussion = this.targetDiscussion;
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
            this.content.TotalLikes++;
            this.lessonSvc.LikeLesson(this.classRoomId, this.lessonId);
        }

        public DisLikeLesson() {
            this.likes.IsLikedLesson = !this.likes.IsLikedLesson;
            this.content.TotalLikes--;
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

        public deleteComfirm(comment: string) {
            this.targetComment = comment;
            this.targetDiscussion = null;
            this.deleteComment = true;
        }

        public deleteDisComfirm(comment: string, discussion: string) {
            this.targetComment = comment;
            this.targetDiscussion = discussion;
            this.deleteComment = false;
        }

    } 

    angular
        .module('app.lessons')
        .controller('app.lessons.LessonController', LessonController);
}