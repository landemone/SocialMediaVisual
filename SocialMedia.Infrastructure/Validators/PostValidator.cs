﻿using FluentValidation;
using SocialMedia.Core.DTOs;
using System;

namespace SocialMedia.Infrastructure.Validators
{
    public class PostValidator: AbstractValidator<PostDto>
    {

        public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .Length(10, 15);
            RuleFor(post => post.Date)
               .NotNull()
               .LessThan(DateTime.Now);

        }
    }
}
