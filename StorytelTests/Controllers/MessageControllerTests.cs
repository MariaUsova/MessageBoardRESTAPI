using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storytel.Services;
using System;
using System.Collections.Generic;

namespace Storytel.Controllers.Tests
{
    [TestClass()]
    public class MessageControllerTests
    {
        private const string MessageId1 = "8c9f4716-3712-4896-84a2-005ce529b0ad";
        private const string MessageId2 = "9e5c67b0-eb9a-4000-8b95-d82119b54d96";
        private const string FakeMessageId = "0e5c67b0-eb9a-4000-1234-d82119b54d96";

        private const int UserId = 1;

        private static Message Message1 = new Message
        {
            Id = new Guid(MessageId1),
            Content = "test content 1",
            CreatedAt = new DateTime(2019, 1, 1),
            UpdatedAt = new DateTime(2019, 1, 2),
            UserId = 1
        };

        private static Message Message2 = new Message
        {
            Id = new Guid(MessageId2),
            Content = "test content 2",
            CreatedAt = new DateTime(2019, 1, 1),
            UpdatedAt = new DateTime(2019, 1, 2),
            UserId = 2
        };

        private List<Message> testMessages = new List<Message>
            { Message1, Message2 };


        [TestMethod()]
        public void GetAllMessagesTest_ShouldReturnAllMessages()
        {
            var controller = GetControllerInstance();
            var result = controller.GetAllMessages() as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

            var messages = result.Value as List<Message>;
            Assert.IsNotNull(messages);
            Assert.AreEqual(testMessages.Count, messages.Count);
        }

        [TestMethod()]
        public void GetMessageTest_ShouldReturnCorrectMessage()
        {
            var controller = GetControllerInstance();

            var result = controller.GetMessage(new Guid(MessageId1)) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

            var message = result.Value as Message;
            Assert.IsNotNull(message);
            Assert.AreEqual(testMessages[0].Content, message.Content);
            Assert.AreEqual(testMessages[0].Id, message.Id);
        }

        [TestMethod()]
        public void GetMessageTest_ShouldReturnNotFound()
        {
            var controller = GetControllerInstance();

            var result = controller.GetMessage(new Guid(FakeMessageId)) as NotFoundResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [TestMethod()]
        public void CreateMessageTest_ShouldCreateAndReturnMessage()
        {
            var testContent = new CreateMessageModel
            {
                Message = "new test content"
            };
            var controller = GetControllerInstance();
            var result = controller.CreateMessage(testContent) as CreatedAtActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status201Created, result.StatusCode);

            var message = result.Value as Message;
            Assert.IsNotNull(message);
            Assert.AreEqual(testContent.Message, message.Content);
        }

        [TestMethod()]
        public void UpdateMessageTest_ShouldUpdateAndReturnMessage()
        {
            var controller = GetControllerInstance();
            var testUpdateMessage = new UpdateMessageModel
            {
                Message = "New updated message"
            };
            var result = controller.UpdateMessage(new Guid(MessageId1), testUpdateMessage) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

            var message = result.Value as Message;
            Assert.IsNotNull(message);
            Assert.AreEqual(testUpdateMessage.Message, message.Content);
        }

        [TestMethod()]
        public void UpdateMessageTest_ShouldReturnForbidden()
        {
            var controller = GetControllerInstance();
            var messageId = new Guid(MessageId2);
            var testUpdateMessage = new UpdateMessageModel
            {
                Message = "New updated message"
            };
            var result = controller.UpdateMessage(messageId, testUpdateMessage) as ForbidResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void UpdateMessageTest_ShouldReturnNotFound()
        {
            var controller = GetControllerInstance();
            var messageId = new Guid(FakeMessageId);
            var testUpdateMessage = new UpdateMessageModel
            {
                Message = "New updated message"
            };
            var message = controller.UpdateMessage(messageId, testUpdateMessage) as NotFoundResult;
            Assert.IsNotNull(message);
            Assert.AreEqual(StatusCodes.Status404NotFound, message.StatusCode);
        }

        [TestMethod()]
        public void DeleteMessageTest_ShouldDeleteMessage()
        {
            var controller = GetControllerInstance();
            var messageId = new Guid(MessageId1);

            var result = controller.DeleteMessage(messageId) as OkResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

            var message = controller.GetMessage(messageId) as NotFoundResult;
            Assert.IsNotNull(message);
            Assert.AreEqual(StatusCodes.Status404NotFound, message.StatusCode);
        }

        [TestMethod()]
        public void DeleteMessageTest_ShouldReturnForbidden()
        {
            var controller = GetControllerInstance();
            var messageId = new Guid(MessageId2);

            var result = controller.DeleteMessage(messageId) as ForbidResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteMessageTest_ShouldReturnNotFound()
        {
            var controller = GetControllerInstance();
            var messageId = new Guid(FakeMessageId);

            var message = controller.DeleteMessage(messageId) as NotFoundResult;
            Assert.IsNotNull(message);
            Assert.AreEqual(StatusCodes.Status404NotFound, message.StatusCode);
        }

        private MessageController GetControllerInstance()
        {
            var mockIHttpContextAccessor = new Mock<IHttpContextAccessor>();

            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(s => s.GetCurrentUserId(mockIHttpContextAccessor.Object)).Returns(UserId);

            MessagesService messageService = new MessagesService();
            messageService.Add(Message1);
            messageService.Add(Message2);

            return new MessageController(
                mockUserService.Object,
                messageService,
                mockIHttpContextAccessor.Object);
        }
    }
}