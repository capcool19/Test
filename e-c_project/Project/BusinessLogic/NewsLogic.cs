using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using DataAcessLayer.Models;

namespace BusinessLogic
{   
    public class NewsLogic
    {
        NewsDAL dal = new NewsDAL();

        public List<News> GetNewsList()
        {
            var news = dal.GetNewsList();
            return news;
        }
        public void CreateNewNews(News news)
        {
            dal.CreateNewNews(news);
        }
        public News GetNewsById(int? id)
        {
            News news = dal.GetNewsById(id);
            return news;
        }
        public void UpdateNews(News news)
        {
            dal.UpdateNews(news);
        }
        public void DeleteNews(int id)
        {
            dal.DeleteNews(id);
        }

    }
}
