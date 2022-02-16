﻿namespace ForumSystem.Web.Areas.Administration.ViewModels.Answers
{
    using System;
    using System.Linq;

    using AutoMapper;

    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class AnswerViewModel : IMapFrom<Answer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Post { get; set; }

        public string AuthorId { get; set; }

        public string Author { get; set; }

        public bool IsDeleted { get; set; }

        public int CommentsCount { get; set; }

        public int ReportsCount { get; set; }

        public int LikesCount { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Answer, AnswerViewModel>()
                .ForMember(a => a.Post, config => config.MapFrom(a => a.Post.Title));
            configuration.CreateMap<Answer, AnswerViewModel>()
                .ForMember(a => a.Author, config => config.MapFrom(a => a.Author.UserName));
            configuration.CreateMap<Answer, AnswerViewModel>()
                .ForMember(a => a.CommentsCount, config => config.MapFrom(a => a.Comments.Count(c => !c.IsDeleted)));
            configuration.CreateMap<Answer, AnswerViewModel>()
                .ForMember(a => a.LikesCount, config => config.MapFrom(a => a.Likes.Count(l => !l.IsDeleted)));
            configuration.CreateMap<Answer, AnswerViewModel>()
                .ForMember(a => a.ReportsCount, config => config.MapFrom(a => a.Reports.Count(r => !r.IsDeleted)));
        }
    }
}