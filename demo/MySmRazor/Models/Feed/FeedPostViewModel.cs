using System;

namespace MySm.Models.Feed
{
    public class FeedPostViewModel
    {
        public string UserAvatarUri { get; set; }
        public string UserNickname { get; set; }
        public string PostedAgo { get; set; }
        public string MainPostImageUri { get; set; }
        public string PostedDate { get; set; }
        public string PostHeader { get; set; }
        public string PostUri { get; set; }
        public string PostedTextPart { get; set; }
        public int CommentsNumber { get; set; }
        public StarsNumber StarsFromYou { get; set; }
        public int StarsNumber { get; set; }
    }
}