using Acme.BookStore.Application.Contracts.Blog;
using Acme.BookStore.Application.Contracts.Blog.Params;
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

            CreateMap<FriendLink, FriendLinkDto>();

            CreateMap<EditPostInput, Post>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<FriendLink, QueryFriendLinkForAdminDto>();

            CreateMap<EditFriendLinkInput, FriendLink>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
