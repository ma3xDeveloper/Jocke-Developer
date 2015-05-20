﻿namespace TrafalgarSquare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Post
    {
        private ICollection<User> favouritedUsers;
        private ICollection<Post> repliedPosts;
        private ICollection<UsersReportedPosts> reportedUsers;

        public Post()
        {
            this.favouritedUsers = new HashSet<User>();
            this.repliedPosts = new HashSet<Post>();
            this.reportedUsers = new HashSet<UsersReportedPosts>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }

        public string PostOwnerId { get; set; }

        public virtual User PostOwner { get; set; }

        public virtual ICollection<UsersReportedPosts> ReportedUsers
        {
            get { return this.reportedUsers; }
            set { this.reportedUsers = value; }
        }

        public int? RepliedPostId { get; set; }

        [ForeignKey("RepliedPostId")]
        public virtual Post RepliedPost { get; set; }

        public virtual ICollection<Post> RepliedPosts
        {
            get { return this.repliedPosts; }
            set { this.repliedPosts = value; }
        }

        public bool? IsReported { get; set; }
    }
}