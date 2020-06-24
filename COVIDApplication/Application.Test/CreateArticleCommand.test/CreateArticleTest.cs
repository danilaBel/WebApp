using Application.Commands.Articles.CreateArticle;
using Domain.Entity;
using Infrastructure_;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Application.Test.CreateArticleCommand.test
{
    [TestClass]
    public class CreateArticleTest
    {
        [TestMethod]
        public void Handle()
        {
            var mediatorMock = new Mock<IMediator>();
            var userManager = 
            var context = new Mock<AppDBContext>();
            userManager.Object.CreateAsync(new AppUser() { Email = "belozarovichdanila08@gmail.com" }, "Belazlol123@");
            var sut = new CreateArticleCommandHandler(context.Object, userManager.Object);
            context.Object.SaveChanges();
            // Act
            var result = sut.Handle(new CreateArticleViewModel {AppUserId= userManager.Object.FindByEmailAsync("belozarovichdanila08@gmail.com").Result.Id, Content="fsdf",Tags="#fsd#fsd",Title="gfdgdf" }, CancellationToken.None);


            // Assert
            Action.ReferenceEquals(result.Result, Unit.Value);
            
           
        }
    }
}
