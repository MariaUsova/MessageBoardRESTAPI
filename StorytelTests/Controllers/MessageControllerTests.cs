using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storytel.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storytel.Controllers.Tests
{
    [TestClass()]
    public class MessageControllerTests
    {
        //[TestMethod()]
        //public void MessageControllerTest()
        //{
        //    //Assert.Fail();
        //}
        //private const string MessageId1 = "8c9f4716-3712-4896-84a2-005ce529b0ad";
        //private const string MessageId2 = "9e5c67b0-eb9a-4000-8b95-d82119b54d96";
        //private readonly ILogger<MessageController> _logger = Mock.Of<ILogger<MessageController>>();

        //[TestMethod()]
        //public void GetAllMessagesTest_ShouldReturnAllMessages()
        //{
        //    var testMessages = GetTestMessages();  
        //    var controller = new MessageController(_logger, testMessages);
        //    var result = controller.GetAllMessages() as OkObjectResult;
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

        //    var messages = result.Value as List<Message>;
        //    Assert.IsNotNull(messages);
        //    Assert.AreEqual(testMessages.Count, messages.Count);
        //}

        

        //[TestMethod()]
        //public void GetMessageTest_ShouldReturnCorrectMessage()
        //{
        //    var testMessages = GetTestMessages();
        //    var controller = new MessageController(_logger, testMessages);

        //    var result = controller.GetMessage(new Guid(MessageId1)) as OkObjectResult;
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

        //    var message = result.Value as Message;
        //    Assert.IsNotNull(message);
        //    Assert.AreEqual(testMessages[0].Content, message.Content);
        //}

        //[TestMethod()]
        //public void CreateMessageTest_ShouldCreateAndReturnMessage()
        //{
        //    var testMessage = new CreateMessageModel
        //    {
        //        Message = "Create message test"
        //    };
        //    var controller = new MessageController(_logger);
        //    var result = controller.CreateMessage(testMessage) as CreatedAtActionResult;

        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(result is CreatedAtActionResult);
        //    Assert.AreEqual(StatusCodes.Status201Created, result.StatusCode);

        //    var message = result.Value as Message;
        //    Assert.IsNotNull(message);
        //    Assert.AreEqual(testMessage.Message, message.Content);
        //}

        //[TestMethod()]
        //public void UpdateMessageTest_ShouldUpdateAndReturnMessage()
        //{
        //    var testMessages = GetTestMessages();
        //    var controller = new MessageController(_logger, testMessages);
        //    var testUpdateMessage = new UpdateMessageModel
        //    {
        //        Message = "New updated message"
        //    };
        //    var result = controller.UpdateMessage(new Guid(MessageId1), testUpdateMessage) as OkObjectResult;
            
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        //    var message = result.Value as Message;
        //    Assert.IsNotNull(message);
        //    Assert.AreEqual(testUpdateMessage.Message, message.Content);
        //}

        //[TestMethod()]
        //public void DeleteMessageTest_ShouldDeleteMessage()
        //{
        //    var testMessages = GetTestMessages();
        //    var controller = new MessageController(_logger, testMessages);
        //    var messageId = new Guid(MessageId1);

        //    var result = controller.GetMessage(messageId) as OkObjectResult;
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

        //    var message = controller.GetMessage(messageId) as NotFoundResult;
        //    Assert.IsNotNull(message);
        //    Assert.IsTrue(message is NotFoundResult);
        //    Assert.AreEqual(StatusCodes.Status404NotFound, message.StatusCode);
        //}

        //private List<Message> GetTestMessages()
        //{
        //    var now = DateTime.UtcNow;
        //    return new List<Message>
        //    {
        //        new Message
        //        {
        //            Id = new Guid(MessageId1),
        //            Content = "test content 1",
        //            CreatedAt = now,
        //            UpdatedAt = now,
        //            UserId = 1
        //        },
        //        new Message
        //        {
        //            Id = new Guid(MessageId2),
        //            Content = "test content 2",
        //            CreatedAt = now,
        //            UpdatedAt = now,
        //            UserId = 2
        //        }
        //    };
        //}


    }
}