using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Themes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using IOFile = System.IO.File;

namespace Kendo.Mvc.Examples
{
    internal class DemoCacheManager
    {
        private object navigationWidgetsLock = new object();
        private bool navigationWidgetsInitialized;
        private IReadOnlyList<NavigationWidget> navigationWidgets;
        private object lessThemesLock = new object();
        private bool lessThemesInitialized;
        private IReadOnlyList<LessTheme> lessThemes;
        private object sassThemesLock = new object();
        private bool sassThemesInitialized;
        private IReadOnlyList<SassTheme> sassThemes;
        private static DemoCacheManager instance;

        public static DemoCacheManager Instance {
            get
            {
                if (instance == null)
                {
                    instance = new DemoCacheManager();
                }

                return instance;
            }
        }

        public virtual IReadOnlyList<NavigationWidget> NavigationWidgets
        {
            get
            {
                return LazyInitializer.EnsureInitialized(
                    ref navigationWidgets,
                    ref navigationWidgetsInitialized,
                    ref navigationWidgetsLock,
                    LoadWidgets);
            }
        }

        public virtual IReadOnlyList<LessTheme> LessThemes
        {
            get
            {
                return LazyInitializer.EnsureInitialized(
                    ref lessThemes,
                    ref lessThemesInitialized,
                    ref lessThemesLock,
                    LoadLessThemes);
            }
        }

        public virtual IReadOnlyList<SassTheme> SassThemes
        {
            get
            {
                return LazyInitializer.EnsureInitialized(
                    ref sassThemes,
                    ref sassThemesInitialized,
                    ref sassThemesLock,
                    LoadSassThemes);
            }
        }

        private IReadOnlyList<NavigationWidget> LoadWidgets()
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var navJson = IOFile.ReadAllText(directory + "content/nav.json");

            return JsonConvert.DeserializeObject<NavigationWidget[]>(navJson.Replace("$FRAMEWORK", "ASP.NET MVC")).OrderBy(x=>x.Name).ToList();
        }

        private IReadOnlyList<LessTheme> LoadLessThemes()
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;

            return JsonConvert.DeserializeObject<LessTheme[]>(IOFile.ReadAllText(directory + "content/themes/less-themes.json"));
        }

        private IReadOnlyList<SassTheme> LoadSassThemes()
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var themes = JsonConvert.DeserializeObject<SassTheme[]>(IOFile.ReadAllText(directory + "content/themes/sass-themes.json"));
            var config = JsonConvert.DeserializeObject<SassTheme[]>(IOFile.ReadAllText(directory + "content/themes/sass-themes-config.json"));

            return themes.Select(theme => new SassTheme
            {
                Name = theme.Name,
                Title = theme.Title,
                Palette = theme.Palette,
                Primary = theme.Primary,
                Swatches = theme.Swatches
                    .Where(swatch => config.SingleOrDefault(c => c.Name.Equals(theme.Name)).Swatches
                    .Any(configSwatch => configSwatch.Name == swatch.Name))
                    .OrderByDescending(od => od.Title == "Main")
                    .ThenBy(on => on.Title)
                    .ToArray()
            }).ToList();
        }
    }
}
