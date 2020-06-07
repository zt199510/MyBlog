using Acme.BookStore.Application.Contracts.Blog;
using Acme.BookStore.Domain.Blog;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Application
{
    public class MeowvBlogAutoMapperProfile:Profile
    {
        public MeowvBlogAutoMapperProfile()
        {
            CreateMap<Post, PostDto>();

            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
