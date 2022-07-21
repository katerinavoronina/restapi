using RestAPI.Models;
using RestAPI.Utils;
using RestSharp;

namespace RestAPI.API
{
    public static class ApplicationAPI
    {
        private static string baseUrl = ConfigManager.ConfigData.BaseUrl;

        public static RestResponse GetAllPostsResponse()
        {
            return ApiUtil.GetRequest(baseUrl, "/posts");
        }

        public static RestResponse GetPostsByIdResponse(int id)
        {
            return ApiUtil.GetRequest(baseUrl, $"/posts/{id}");
        }

        public static RestResponse PostPost(Post post)
        {
            return ApiUtil.PostRequest(baseUrl, "/posts", post);
        }

        public static RestResponse GetAllUsersResponse()
        {
            return ApiUtil.GetRequest(baseUrl, "/users");
        }

        public static RestResponse GetUserByIdResponse(int id)
        {
            return ApiUtil.GetRequest(baseUrl, $"/users/{id}");
        }
    }
}
