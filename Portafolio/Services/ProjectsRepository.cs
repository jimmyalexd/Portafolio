using Portafolio.Models;

namespace Portafolio.Services
{
    public interface IProjectsRepository
    {
        List<Project> GetProjects();
    }

    public class ProjectsRepository: IProjectsRepository
    {
        public List<Project> GetProjects()
        {
            return new List<Project>() {
                new Project
            {
                Title = "Amazon",
                Description = "E-Commerce realizado en ASP.NET Core",
                Link = "https://amazon.com",
                ImageURL = "/images/amazon.png"
            },

                new Project
            {
                Title = "New York Times",
                Description = "Página de noticias en React ",
                Link = "https://nytimes.com",
                ImageURL = "/images/nyt.png"
            },

                new Project
            {
                Title = "Reddit",
                Description = "Red social para compartir en comunidades",
                Link = "https://reddit.com",
                ImageURL = "/images/reddit.png"
            },

                new Project
            {
                Title = "Steam",
                Description = "Tienda en línea para comprar videojuegos",
                Link = "https://store.steampowered.com",
                ImageURL = "/images/steam.png"
            },
            };
        }
    }
}