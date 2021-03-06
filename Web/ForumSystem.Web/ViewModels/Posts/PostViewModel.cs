namespace ForumSystem.Web.ViewModels.Posts
{
    using System;
    using System.Linq;

    using AutoMapper;

    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string AuthorId { get; set; }

        public string AuthorPictureUrl { get; set; }

        public string Author { get; set; }

        public int ReportsCount { get; set; }

        public int LikesCount { get; set; }

        public int AnswersCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsPinned { get; set; }

        public bool IsLocked { get; set; }

        public string LockedById { get; set; }

        public string LockedBy { get; set; }

        public string LockReason { get; set; }

        public int Views { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(p => p.Author, config => config.MapFrom(p => p.Author.UserName));
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(p => p.Category, config => config.MapFrom(p => p.Category.Title));
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(p => p.AuthorPictureUrl, config => config.MapFrom(p => p.Author.PictureUrl));
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(p => p.ReportsCount, config => config.MapFrom(p => p.Reports.Count(r => !r.IsDeleted)));
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(p => p.LikesCount, config => config.MapFrom(p => p.Likes.Count(l => !l.IsDeleted)));
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(p => p.AnswersCount, config => config.MapFrom(p => p.Answers.Count(a => !a.IsDeleted)));
        }
    }
}