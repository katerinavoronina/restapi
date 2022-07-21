using NUnit.Framework;
using RestAPI.API;
using RestAPI.Models;
using RestAPI.Utils;
using RestSharp.Serializers;
using System.Linq;
using System.Net;

namespace RestAPI.Tests
{
    public class APITests
    {
        [Test]
        public void GetPostRequestTest()
        {
            var responseAllPosts = ApplicationAPI.GetAllPostsResponse();
            var allposts = DeserializationUtil.GetResponseContentList<Post>(responseAllPosts.Content);
            var sortposts = allposts.OrderBy(post => post.Id).ToList();

            Assert.NotNull(responseAllPosts, "Response is null");
            Assert.AreEqual(responseAllPosts.ContentType, ContentType.Json, $"Content type = {responseAllPosts.ContentType}");
            Assert.AreEqual(responseAllPosts.StatusCode, HttpStatusCode.OK, $"status code = {responseAllPosts.StatusCode}");
            Assert.IsTrue(allposts.SequenceEqual(sortposts), $"Posts are not sorted ascending");

            int postId = 99;
            int userId = 10;
            
            var responseExistPost = ApplicationAPI.GetPostsByIdResponse(postId);
            var post = DeserializationUtil.GetResponseContent<Post>(responseExistPost.Content);

            Assert.AreEqual(responseExistPost.StatusCode, HttpStatusCode.OK, $"status code = {(int)responseExistPost.StatusCode}");
            Assert.AreEqual(post.Id, postId, "Id are not equal");
            Assert.AreEqual(post.UserId, userId, "UserId is not 10");
            Assert.NotNull(post.Title, "title is empty");
            Assert.NotNull(post.Body, "Body is empty");

            postId = 150;
            var responseNonExistPost = ApplicationAPI.GetPostsByIdResponse(postId);

            Assert.AreEqual(responseNonExistPost.StatusCode, HttpStatusCode.NotFound, $"status code={(int)responseNonExistPost.StatusCode}");
            Assert.AreEqual(responseNonExistPost.Content, "{}", $"Response body is not empty");

            Post testPost = new Post()
            {
                UserId = 1,
                Title = RandomUtil.GetRandomString(),
                Body = RandomUtil.GetRandomString()
            };

            var responsePostRequest = ApplicationAPI.PostPost(testPost);
            var addedPost = DeserializationUtil.GetResponseContent<Post>(responsePostRequest.Content);

            Assert.AreEqual(responsePostRequest.StatusCode, HttpStatusCode.Created, $"status code={responsePostRequest.StatusCode}");
            Assert.AreEqual(addedPost.UserId, testPost.UserId, "UserId are not equal");
            Assert.AreEqual(addedPost.Title, testPost.Title, "Titles are not equal");
            Assert.AreEqual(addedPost.Body, testPost.Body, "Bodies are not equal");
            Assert.NotNull(addedPost.Id, "Id is not present");

            var responseAllUsers = ApplicationAPI.GetAllUsersResponse();
            var user5 = DeserializationUtil.GetResponseContentList<User>(responseAllUsers.Content).Find(item => item.Id == 5);
            var testUser = TestUserData.User;

            Assert.AreEqual(responseAllUsers.StatusCode, HttpStatusCode.OK, $"status code={responseAllUsers.StatusCode}");
            Assert.AreEqual(responseAllUsers.ContentType, ContentType.Json, $"Content type = {responseAllUsers.ContentType}");
            Assert.IsTrue(testUser.Equals(user5), "Users are not equal");

            userId = 5;
            var responseUserById = ApplicationAPI.GetUserByIdResponse(userId);
            var user = DeserializationUtil.GetResponseContent<User>(responseUserById.Content);
            var user1 = TestUserData.User;

            Assert.IsTrue(user.Equals(user1), "Users are not equal");
            Assert.AreEqual(responseUserById.StatusCode, HttpStatusCode.OK, $"status code={responseUserById.StatusCode}");
        }
    }
}
