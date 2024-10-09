using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTestMVC.Models;
using MySql.Data.MySqlClient;

namespace WebApplicationTestMVC.Controllers
{
    public class PostController : Controller
    {
        // GET: PostController
        public ActionResult Index()
        {
            List<Post> posts = new List<Post>();

            string conString = "Server=localhost;Database=TestMVC;Uid=TestMVC;Pwd=TestMVC1!;";
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            string sqlQuery = "select * from post";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Post newPost = new Post();
                newPost.id = reader.GetInt32("id");
                newPost.Title = reader.GetString("Title");
                newPost.Author = reader.GetString("Author");
                newPost.PostDate = reader.GetDateTime("PostDate");
                posts.Add(newPost);
            }
            reader.Close();

            conn.Close();

            return View(posts);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            string conString = "Server=localhost;Database=TestMVC;Uid=TestMVC;Pwd=TestMVC1!;";
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            string sqlQuery = "select * from post where id=" + id.ToString();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            MySqlDataReader reader = cmd.ExecuteReader();
            Post newPost = new Post();
            while (reader.Read())
            {
                newPost.id = reader.GetInt32("id");
                newPost.Title = reader.GetString("Title");
                newPost.Author = reader.GetString("Author");
                newPost.PostDate = reader.GetDateTime("PostDate");
            }
            reader.Close();

            conn.Close();

            return View(newPost);
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            string conString = "Server=localhost;Database=TestMVC;Uid=TestMVC;Pwd=TestMVC1!;";
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            string sqlQuery = "select * from post where id=" + id.ToString();
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

            MySqlDataReader reader = cmd.ExecuteReader();
            Post newPost = new Post();
            while (reader.Read())
            {
                newPost.id = reader.GetInt32("id");
                newPost.Title = reader.GetString("Title");
                newPost.Author = reader.GetString("Author");
                newPost.PostDate = reader.GetDateTime("PostDate");
            }
            reader.Close();

            conn.Close();

            return View(newPost);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Post post)
        {
            try
            {
                string conString = "Server=localhost;Database=TestMVC;Uid=TestMVC;Pwd=TestMVC1!;";
                MySqlConnection conn = new MySqlConnection(conString);
                conn.Open();

                string sqlQuery = "update Post set title = '" + post.Title + "', author = '" + post.Author + "' where id=" + id.ToString();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                cmd.ExecuteNonQuery();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
