using Kendo.Mvc.Examples.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TimelineEventsController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            List<TimelineEventModel> events = new List<TimelineEventModel>();

            events.Add(new TimelineEventModel() {
                Title = "Barcelona \u0026 Tenerife",
                Subtitle = "May 25, 2008",
                Description = "Barcelona is an excellent place to discover world-class arts and culture. Bullfighting was officially banned several years ago, but the city remains rich with festivals and events. The sights in Barcelona are second to none. Don’t miss the architectural wonder, Casa Mila—otherwise known as La Pedrera. It’s a modernist apartment building that looks like something out of an expressionist painting. Make your way up to the roof for more architectural surprises. And if you like Casa Mila, you’ll want to see another one of Antoni Gaudi’s architectural masterpieces, Casa Batllo, which is located at the center of Barcelona.\r\nTenerife, one of the nearby Canary Islands, is the perfect escape once you’ve had your fill of the city. In Los Gigantes, life revolves around the marina.",
                EventDate = new System.DateTime(2008, 5, 25),
                AltField = "Arc de Triomf, Barcelona, Spain",
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "https://demos.telerik.com/aspnet-mvc/tripxpert/Images/Gallery/Barcelona-and-Tenerife/Arc-de-Triomf,-Barcelona,-Spain_Liliya-Karakoleva.JPG?width=500&amp;height=500" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Barcelona", url="https://en.wikipedia.org/wiki/Barcelona" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "United States East Coast Tour 1",
                Subtitle = "Feb 27, 2007",
                Description = "Touring the East Coast of the United States provides a massive range of entertainment and exploration. To take things in a somewhat chronological order, best to begin your trip in the north, checking out Boston’s Freedom Trail, Fenway Park, the Statue of Liberty, and Niagara Falls. Bring your raincoat to Niagara Falls, which straddles the boarder between Canada and the United States—the majestic sight might have you feeling misty in every sense of the word.",
                EventDate = new System.DateTime(2007, 2, 27),
                AltField = "Boston Old South Church",
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "https://demos.telerik.com/aspnet-mvc/tripxpert/Images/Gallery/United-States/Boston-Old-South-Church_Ivo-Igov.JPG?width=500&amp;height=500" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about New York City", url="https://en.wikipedia.org/wiki/New_York_City" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Malta, a Country of Knights",
                Subtitle = "Jun 15, 2008",
                Description = "Home of the oldest-known human structures in the world, the Maltese archipelago is best described as an open-air museum. Malta, the biggest of the seven Mediterranean islands, is the cultural center of the three largest—only three islands that are fully inhabited.  If you’re into heavy metal—swords, armor and other medieval weaponry—you’ll love the Grandmaster’s Palace.",
                EventDate = new System.DateTime(2008, 6, 15),
                AltField = "Bibliotheca National Library Marie Lan Nguyen",
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "https://demos.telerik.com/aspnet-mvc/tripxpert/Images/Gallery/Malta/Bibliotheca-National-Library_Marie-Lan-Nguyen.JPG?width=500&amp;height=500" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Malta", url="https://en.wikipedia.org/wiki/Malta" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Wonders of Italy",
                Subtitle = "Jul 6, 2008",
                Description = "The Italian Republic is a history lover’s paradise with thousands of museums, churches and archaeological sites dating back to Roman and Greek times. Visitors will also find a hub for fashion and culture unlike anywhere else in the world. Explore Ancient history in Rome at the Colosseum and Rome’s Ruins.",
                EventDate = new System.DateTime(2008, 7, 6),
                AltField = "Basilica di San Pietro in Vaticano",
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "https://demos.telerik.com/aspnet-mvc/tripxpert/Images/Gallery/Italy/Basilica-di-San-Pietro-in-Vaticano2_Lilia-Karakoleva.jpg?width=500&amp;height=500" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Rome", url="https://en.wikipedia.org/wiki/Rome" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "The Best of Western Europe",
                Subtitle = "Aug 11, 2009",
                Description = "Tour the best of Western Europe and take in the sights of Munich, Frankfurt, Meinz, Bruxel, Amsterdam, and Vienna along the way. Discover the amazing world of plants at Frankfurt Palmengarten, the botanical gardens in Frankfurt.",
                EventDate = new System.DateTime(2009, 8, 11),
                AltField = "Austrian Parliament, Vienna, Austria",
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "https://demos.telerik.com/aspnet-mvc/tripxpert/Images/Gallery/Western-Europe/Austrian-Parliament,-Vienna,-Austria_Gergana-Prokopieva.JPG?width=500&amp;height=500" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Munich", url="https://en.wikipedia.org/wiki/Munich" }
                }
            });

            return Json(events, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetHorizontalTemplatesEvents()
        {
            List<TimelineEventModel> events = new List<TimelineEventModel>();

            events.Add(new TimelineEventModel()
            {
                Title = "Barcelona \u0026 Tenerife",
                Subtitle = "May 25, 2008",
                Description = "Barcelona is an excellent place to discover world-class arts and culture. Bullfighting was officially banned several years ago, but the city remains rich with festivals and events. The sights in Barcelona are second to none. Don’t miss the architectural wonder, Casa Mila—otherwise known as La Pedrera. It’s a modernist apartment building that looks like something out of an expressionist painting. Make your way up to the roof for more architectural surprises. And if you like Casa Mila, you’ll want to see another one of Antoni Gaudi’s architectural masterpieces, Casa Batllo, which is located at the center of Barcelona.\r\nTenerife, one of the nearby Canary Islands, is the perfect escape once you’ve had your fill of the city. In Los Gigantes, life revolves around the marina. Take a boat out in search of bottlenose dolphins and whales. For the able-bodied visitor, take a climb up “Cardiac Hill” to get a breathtaking view—and workout. While you’re in Tenerife, visit Mount Teide. It’s the highest point in Spain and the third-largest volcano in the world.\r\n",
                EventDate = new System.DateTime(2008, 5, 25),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Barcelona_Tenerife_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Barcelona_Tenerife_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Barcelona", url = "https://en.wikipedia.org/wiki/Barcelona" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "United States East Coast Tour 1",
                Description = "Touring the East Coast of the United States provides a massive range of entertainment and exploration. To take things in a somewhat chronological order, best to begin your trip in the north, checking out Boston’s Freedom Trail, Fenway Park, the Statue of Liberty, and Niagara Falls. Bring your raincoat to Niagara Falls, which straddles the boarder between Canada and the United States—the majestic sight might have you feeling misty in every sense of the word. Bring your walking shoes to the Freedom Trail. The 2.5-mile walk will take you on an historical tour of sites relevant to the American Revolution. When you visit Fenway Park, you might be wise to bring a helmet. With fly balls that average a speed of 100 miles per hour, you can never be too safe. Bring a healthy set of lungs to the Statue of Liberty and remember to make an advanced reservation if you’d like to climb the stairs to Lady Liberty’s crown. Finish up your tour at the south end of the coast with Kennedy Space Center in Florida and be sure to bring the kids. Everyone will get the chance to touch an authentic moon rock and stand under the largest rocket ever flown.",
                Subtitle = "Jun 15, 2008",
                EventDate = new System.DateTime(2008, 6, 15),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/United_States_East_Coast_tour_1_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/United_States_East_Coast_tour_1_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about New York City", url = "https://en.wikipedia.org/wiki/New_York_City" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Malta, a Country of Knights",
                Description = "Home of the oldest-known human structures in the world, the Maltese archipelago is best described as an open-air museum. Malta, the biggest of the seven Mediterranean islands, is the cultural center of the three largest—only three islands that are fully inhabited.  If you’re into heavy metal—swords, armor and other medieval weaponry—you’ll love the Grandmaster’s Palace. It houses a magnificent collection of ornate battle gear. Visit the National Museum of Archaeology to see a spectacular range of artifacts dating back to Malta’s Neolithic period (5000 BC). And for some fresh air and picturesque views, be sure not to miss the Lower Barrakka Gardens. It’s a particularly idea place to take in the magnificent view of the Grand Harbour. Last, but not least, don’t miss the Church of St. Catherine of Alexandria. This recently restored church is an ideal place to see Mattia Preti’s refined style up close.",
                Subtitle = "Feb 27, 2007",
                EventDate = new System.DateTime(2007, 2, 27),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Malta_a_country_of_knights_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Malta_a_country_of_knights_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Malta", url = "https://en.wikipedia.org/wiki/Malta" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Wonders of Italy",
                Subtitle = "Jul 6, 2008",
                Description = "The Italian Republic is a history lover’s paradise with thousands of museums, churches and archaeological sites dating back to Roman and Greek times. Visitors will also find a hub for fashion and culture unlike anywhere else in the world. Explore Ancient history in Rome at the Colosseum and Rome’s Ruins. Rome’s greatest gladiator arena has history of unimaginable violence—games that would last 100 days in some cases and involve the slaughter of up to 10,000 animals—but today, it is one of the most majestic sites for Italian tourism. Take a trip to the Sistine Chapel in Vatican City where Michelangelo’s Genesis (Creation), commissioned by Pope Julius II and painted by Michelangelo between 1508 and 1512, attracts droves of visitors each year. Take a waterbus tour of the Grand Canal and stop along the way for a bite to eat and some shopping. Take in the most famous of the city’s churches and one of the best known examples of the Italo-Byzantine architecture, the Basilica of Saint Mark, which lies at the eastern end the Piazza San Marco, adjacent and connected to the Doge’s Palace. And don’t miss the Duomo of Florence.",
                EventDate = new System.DateTime(2008, 7, 6),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Wonders_of_Italy_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Wonders_of_Italy_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Rome", url = "https://en.wikipedia.org/wiki/Rome" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "The Best of Western Europe",
                Subtitle = "Aug 11, 2009",
                Description = "Tour the best of Western Europe and take in the sights of Munich, Frankfurt, Meinz, Bruxel, Amsterdam, and Vienna along the way. Discover the amazing world of plants at Frankfurt Palmengarten, the botanical gardens in Frankfurt. The Frankfurt Palmengarten is home to 50 acres of tropical trees, orchids and ferns. Stop along the Frankfurt Bridge, affectionately referred to as the Love Bridge, and attach a padlock to the bridge before throwing the key into the river Main. Such is the tradition of love-struck visitors. Visit the Triumphal Arch Brussels. The Arch was planned for the world exhibition of 1880 and was meant to commemorate the 50th anniversary of the independence of Belgium. However, the construction took longer than expected and was completed just in time for the nations 75th anniversary of independence. Don’t miss Vienna’s natural history museum—one of the oldest, largest and most noteworthy natural history museums in the world. Last, but not least, don’t miss the Nymphenburg Palace in Munich. It’s Baroque masterpiece and an architecture lover’s dream.",
                EventDate = new System.DateTime(2009, 8, 11),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/The_Best_of_Western_Europe_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/The_Best_of_Western_Europe_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Munich", url = "https://en.wikipedia.org/wiki/Munich" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "UNESCO Sites in Bulgaria",
                Subtitle = "Mar 13, 2009",
                Description = "Bulgaria is located in the heart of the Balkans, sharing boarders with Serbia, Macedonia, Romania, Greece and Turkey. Visitors will be greeted by a unique blend of enchanting monasteries, friendly people and old-world charm. Bulgaria has a democratic government and is one of the oldest states in Europe. Its Black Sea coast draws tourists all year long. \r\n\r\nDon’t miss the frescos at Rila Monastery. This mesmerizing monastery is named after its founder, the hermit Ivan of Rila and has a style unlike any other monastery on the globe. \r\nDuring your stay, you will also want to check out the Alexander Nevsky Cathedral. This Bulgarian Orthodox cathedral is built in Neo-Byzantine style and located in the heart of Sophia.\r\nOutside the city, near the village of Madara, the Madara Rider rock relief carving is a must-see. This mysterious piece of art dates back to 710 AD.\r\nLastly, be sure to see the Basilica of the Holy Mother of God Eleusa and the Church of St. George while you’re here. \r\n",
                EventDate = new System.DateTime(2009, 3, 13),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/UNESCO_Sites_in_Bulgaria_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/UNESCO_Sites_in_Bulgaria_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Plovdiv", url = "https://en.wikipedia.org/wiki/Plovdiv" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "India, Golden Triangle Khajuraho and Varanasi",
                Subtitle = "Apr 23, 2010",
                Description = "On your visit to India, enjoy the majesty of palaces and opulent architecture. Along your journey, don’t miss the Gateway of India, built to commemorate the power of the British Empire. Visit the great mosque of Old Delhi, India’s largest mosque, with a courtyard large enough to hold a mind-blowing 25,000 devotees. Of course, no trip to India would be complete without taking the time to visit one of the Seven Wonders of the World, the Taj Mahal. The moods of the Taj Mahal vary from dawn to dusk and the morning is recommended as the most alluring time to visit. Watch the color of its sweeping marble surfaces change from soft gray and yellow to pearly cream and sparkling white and experience the symbolic presence of Allah. Before your trip is done, take an elephant ride outside the Amber Fort. These rides are very popular, so those interested in taking one will need to arrive very early in the morning to ensure they don’t get caught in a long line and miss the chance.",
                EventDate = new System.DateTime(2010, 4, 23),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/India_Golden_Triangle_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/India_Golden_Triangle_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Delhi", url = "https://en.wikipedia.org/wiki/Delhi" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Highlights of South Africa",
                Subtitle = "Nov 13, 2012",
                Description = "Africa provides some of the most epic wildlife diversity on the planet. Not many vacations involve sleeping in close quarters with lions, leopards, elephants, Cape buffaloes, black rhinos, cheetahs, giraffes and hippos. But South Africa is unique in the fact that it has so much unspoiled lands—like the Featherbed Private Nature Reserve at the western head of Kynysna. It’s one of South Africa’s Natural Heritage Sites that can only be reached by ferry. Kruger National Park, a nature preserve in the northeastern corner of South Africa, is 5 million acres. It’s not a zoo so you aren’t guaranteed to see certain animals at certain times. But it’s the lack of predictability that makes a safari so magical. For a more urban experience, walk the Nelson Mandela Bridge and visit the Apartheid Museum in Johannesburg.",
                EventDate = new System.DateTime(2012, 11, 13),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Highlights_of_South_Africa_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Highlights_of_South_Africa_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Cape Town", url = "https://en.wikipedia.org/wiki/Cape_Town" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Costa Rican Treasures",
                Subtitle = "Feb 13, 2013",
                Description = "Whether you’re a surfing enthusiast or just interested in taking an exotic adventure, Costa Rica offers a wide variety of adventuring options. Tour the Tarcoles River to see some major crocodile action from the safety of a boat. The Tarcoles has one of the highest populations of crocodiles in the world with 25 crocodiles per square kilometer. Prefer flowers to flesh-chomping wildlife? Make a day of orchid sniffing. Learn all about these enchanting plants at the Orchid Botanical Garden. You’ll get the chance to visit the orchid lab where they create most of the flowers on the property. At Barra Honda National Park, visitors can explore a system of limestone caves. Bats live there so don’t be afraid if you see one—or 5,000. Last but not least, be sure to check out the Poas Volcano. It may be the most convenient volcano exploration you’ll ever do. You can drive right to the visitor’s center and take a mere 15-minute walk to the main crater.",
                EventDate = new System.DateTime(2013, 2, 13),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Costa_Rican_Treasures_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Costa_Rican_Treasures_2_.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Costa Rica", url = "https://en.wikipedia.org/wiki/Costa_Rica" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Brazil and Argentina Iguazu Falls",
                Subtitle = "Apr 13, 2013",
                Description = "With a population over 200 million, the Federative Republic of Brazil is the fifth most populous country in the world, and Rio de Janeiro is its largest city. Vibrating to the alluring sounds of samba, Rio’s residents, known as cariocas, are examples of how to live well. From the renowned beaches of Copacabana and Ipanema to the tops of scenic outlooks of Corcovado and Pão de Açúcar to the dance halls, bars and open-air cafes that give the city its life, cariocas live for the moment without a care in the world. Visitors visit Rio to get a taste of this lifestyle which balances the city scene with natural beauty of the beaches and rainforests, including Prainha and Tijuca respectively.  \r\nRio also juxtaposes a spectacular landscape with a gritty urban scene. Rio d Janeiro is a crime-ridden city, but much can be done to ensure a safe and enjoyable visit provided basic precautions are observed. There are many residents—native and otherwise—that wouldn’t consider living anywhere else. Rio is a great destination for travelers seeking a vibrant cultural experience. \r\n",
                EventDate = new System.DateTime(2013, 4, 13),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Brazil_and_Argentina_Iguazu_Falls_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Brazil_and_Argentina_Iguazu_Falls_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Rio de Janeiro", url = "https://en.wikipedia.org/wiki/Rio_de_Janeiro" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Cuba Paradise Island",
                Subtitle = "Jun 16, 2013",
                Description = "Cuba provides a unique travel destination that is equal parts relaxation and education. You’ll find beautiful beaches, rum and some incredible and historically significant locations. Dubbed, “Pearl of the South”, Cienfuegos was originally founded in 1819 as a settlement by French emigrants from Bordeaux and Louisiana. Rum-drinking men and sundrenched women made this beach town their home. The sprawling white sand beaches of Varadero provide plenty of real estate a broad range of resorts, from family-friendly to all-inclusive and everything in between. History lovers won’t want to miss the opportunity to visit Freedom Square (Plaza de la Revolucion), a square in Havana, Cuba. Freedom Square is the largest city square in the world. And last, but not least, take an educational tour and learn all the interesting facts and details about how rum is made. An expert guide will explain the whole process behind rum making and a cute model train set will help illustrate the layout of the distillery.",
                EventDate = new System.DateTime(2013, 6, 16),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Cuba_Paradise_Island_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Cuba_Paradise_Island_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Havana", url = "https://en.wikipedia.org/wiki/Havana" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Egypt Explorer",
                Subtitle = "Apr 12, 2014",
                Description = "Get ready to feel small. Exploring Egypt will put you face-to-face with the ancient Egyptian civilization and their colossal structures—awe-inspiring monuments to the pharos and the gods. Egypt is best known for the Great Pyramids at Giza. The three pyramids—Cheops, Khafre and Menakaure—and the Sphinx are majestic icons of Egypt. However, there are actually over 100 pyramids in Egypt, many of which remain relatively unknown to anyone who is not an ancient Egypt enthusiast. There are tons of temples and ruins to discover and some can only be reached via watercraft. A general rule of thumb is to join a group tour. This will reduce the hassle of negotiating taxi rates and help you fend off solicitors once you reach your destination. You’ll want to check on travel advisories to be sure that you’re travel plans are well timed so that you can enjoy this amazing country to its full potential.",
                EventDate = new System.DateTime(2014, 4, 12),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Egypt_Explorer_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Egypt_Explorer_2_.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Cairo", url = "https://en.wikipedia.org/wiki/Cairo" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "England, Scotland \u0026 Wales",
                Subtitle = "Nov 23, 2014",
                Description = "Fancy a proper holiday? Well you’ve come to the right place. This city has a lot to do so make a plan if you want to experience all that classic London has to offer. Take a walk across the River Thames on the Millennium steel-suspension footbridge and peruse the fine art at the Tate Modern. Jump into the London Eye and ride it to the top of the city, an insane 135 meters above the river below. Keep the day going by sauntering over to the iconic parliament buildings and saying hello to Big Ben. Make your way to Camden for a little vintage shopping and a relaxing meal or drink. If it’s your first time visiting, you might want to hop on a double decker bus, snap a photo in a telephone booth or try to get the palace guards to crack a smile—because that’s just what people do when they visit London for the first time. ",
                EventDate = new System.DateTime(2014, 11, 23),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/England_Scotland_Wales_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/England_Scotland_Wales_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about London", url = "https://en.wikipedia.org/wiki/London" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Golden Myanmar",
                Subtitle = "May 12, 2015",
                Description = "Myanmar is home to some of the most sacred places on Earth for Buddhists. Multiple pagodas (temples) house strands of Buddha’s hair. Visit the Taungkalat shrine, home to 37 Mahagiri Nats—animist spirit entities—once so important to the country’s early kings that they would consult the Nats before commencing their reign. You’ll have to climb 777 steps to reach it and you’ll make the journey without any shoes or socks. Tradition is important to the people here in Myanmar. Evidence can be seen in the pious devotees performing deeds of religious merit outside the pagodas. You’ll want to remember to dress conservatively when visiting a temple and remove your shoes and socks before entering a sacred space. A recurring theme you’ll notice is lots of opulent “bling” and gilded spires jetting into the sky. Generally speaking, the cost of your trip will be low but tourist are heavily taxed by the government, so a hotel with extremely modest accommodations might cost you as much as $25 a night.  ",
                EventDate = new System.DateTime(2015, 5, 12),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Golden_Myanmar_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Golden_Myanmar_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Myanmar", url = "https://en.wikipedia.org/wiki/Myanmar" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Imperial China",
                Subtitle = "Jul 12, 2015",
                Description = "The ancient sights of China are otherworldly. From the Terracotta Army to the cave carvings at Dragon Gate, the immensity of these Chinese attractions is matched only by the diligence in their details. As you travel down the Yi River, the Great Wall, or enter the archeological excavation of 7,000 life-sized warriors and horses created to guard Qin Shi Huang in the afterlife, you may get the feeling that your travels have leapt beyond the geographical—you may feel as though you have traveled through time. \r\nOne of the less whimsical aspects of your travels will take place in the bathroom. Don’t expect toilet paper to be provided. Be sure to carry your own supplies. Similarly, you’ll want to download a language app to help with translation. If you find yourself in a jam, look for a young person to help you translate. Students under 25-years old are most likely to speak English in addition to Mandarin. \r\n",
                EventDate = new System.DateTime(2015, 7, 12),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Imperial_China_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Imperial_China_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Bejing", url = "https://en.wikipedia.org/wiki/Bejing" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Kenya",
                Subtitle = "Apr 23, 2016",
                Description = "Adventuring through Kenya is no day at the beach. But those willing to brave this raw and wild area of the world will be rewarded with sights and experiences that will last a lifetime. The Great Rift Valley is home to some pretty unique creatures so don’t be surprised if you have moments in which you question whether you are in fact awake or actually dreaming. If you venture to Kenya between July and October, you will be lucky enough to witness one of nature’s biggest wildlife spectacles, the Great Migration. Catch the wildebeests crossing the river from a hot-air balloon while you sip Champaign and don’t be alarmed if you spot a wild lion, leopard or cheetah down below. Take a hike at Mount Kilimanjaro, the tallest freestanding volcano on Earth at a staggering four miles high. Don’t worry if you can’t make it to the snow-capped summit, only about 50 percent of hikers are able to reach the top.",
                EventDate = new System.DateTime(2016, 4, 23),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Kenya_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Kenya_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Kenya", url = "https://en.wikipedia.org/wiki/Kenya" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "United States East Coast Tour 2",
                Subtitle = "Apr 23, 2017",
                Description = "The Big Apple is a living city, perhaps more so than any other city on Earth. When people come to New York, they fall in love. Not with some local person, restaurant, building, or bar—they fall in love with the city as a whole. It’s easy to see why when you step back and examine the endless variety of life NYC has to offer. It’s almost like a bag filled with hundreds of Broadway sets exploded and all the charming pieces of this city just fell right into place. A twilight stroll across the Brooklyn Bridge, an afternoon of kite flying (or picnicking) in Central Park, a Broadway show or just a couple hours of wandering through Greenwich Village and you’ll be well on your way to NYC infatuation. Don’t expect to see it all in one trip. That will only leave you feeling exhausted and unsuccessful. Chances are, you’ll want to return soon anyway. This tour packs another city you wouldn’t want to miss – Washington D.C. Prepare to be fully captivated by the Nation\u0027s Capitol seen at night and the breathtaking views of the national monuments and federal buildings flooded in lights. The US Capitol Building, the Kennedy Center, the Washington Monument and the Federal Triangle are just a tiny part of everything Washington has to offer.  ",
                EventDate = new System.DateTime(2017, 4, 23),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/United_States_East_Coast_Tour_2_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/United_States_East_Coast_Tour_2_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Boston", url = "https://en.wikipedia.org/wiki/Boston" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Spectacular Highlights of Turkey and Greece",
                Subtitle = "Jun 12, 2023",
                Description = "Turkey and Greece—two countries filled with ancient history and breathtaking scenery—make the perfect combo for a luxurious vacation with soul. Istanbul is coated in a texture of beautiful details, giving visitors ornate and tasty souvenirs to take home after their visit. The Eminonu quarter of the Faith district is home to the Spice Bazaar, one of the largest bazaars in the city. Try before you buy and do as the locals do in order to get the most value out of your visit. There will be lots to choose from and you might have trouble differentiating between the high- and low-quality shops otherwise. Greece is, of course, filled with architectural marvels including the Erechtheum, an iconic temple in Athens. The Porch of the Maidens is as distinctive today as it was when it was completed in 406 BC. Ladies, bring a scarf to cover your hair if you visit a mosque. Or, better yet, buy one during your travels to remember your vacation by.",
                EventDate = new System.DateTime(2023, 6, 12),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Turkey_and_Greece_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/Turkey_and_Greece_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Istanbul", url = "https://en.wikipedia.org/wiki/Istanbul" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "The Best of Japan",
                Subtitle = "Oct 12, 2015",
                Description = "Japan consists of four major islands (Honshu, Hokkaido, Kyushu and Shikoku) and over 4,000 smaller islands, all full of culture, history and natural beauty. The Sea of Japan separates the Japanese archipelago from the Asian continent and its closest neighbors, China, Korea and Russia. Japan’s population of 126 million are the life force of a nation where modern technology abuts deep and enduring cultural traditions. From castles, gardens and temples to cities, mountains and ocean wonders, Japan offers a diverse and secure vacation for visitors the world over. Comprising 23 special wards, 26 cities, 5 towns and 8 villages, Tokyo is the political, economic and cultural center of Japan. Fuji is surrounded by the Ashitaka mountain range, within sight of the majestic Mount Fuji to the north, and works hard to preserve the beauty and natural surroundings of the city. Explore the ocean sports, mountain peaks, nightlife and ancient mysteries that are Japan.",
                EventDate = new System.DateTime(2015, 10, 12),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/The_Best_of_Japan_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/The_Best_of_Japan_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Tokyo", url = "https://en.wikipedia.org/wiki/Tokyo" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "The Best of Central Europe",
                Subtitle = "Oct 11, 2024",
                Description = "On your journey through the culturally rich countries of Central Europe, you’ll find a wide variety of sights and experiences. There is a world of history in Germany, the Czech Republic, Slovakia, and Hungary, and lots to be learned along the way. Many attractions will provide a first-hand look at the sites where some of our world’s most defining moments have taken place—both joyous and tragic. Visit the remains of the Berlin Wall and learn more about the somewhat recent conflicts that tore Germany in two—and the reunification that followed. In Prague, take a lighter look at our recent history with a visit to the architecturally mesmerizing “Dancing House” designed by Croatian-Czech architect, Vlado Milunic and Canadian-American architect, Frank Gehry. Be sure to call ahead and find out if you need an appointment as some of the most historical landmarks can become busy and require reservations for full access to the building or site.",
                EventDate = new System.DateTime(2024, 10, 11),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/The_Best_of_Central_Europe_1.jpg" },
                    new TimelineEventModelImage() { src = "../content/web/timeline/templates-images/The_Best_of_Central_Europe_2.jpg" }
                },
                Actions = new List<TimelineEventModelAction>() {
                    new TimelineEventModelAction() { text = "More info about Prague", url = "https://en.wikipedia.org/wiki/Prague" }
                }
            });

            return Json(events, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetHorizontalEvents()
        {
            List<TimelineEventModel> events = new List<TimelineEventModel>();

            events.Add(new TimelineEventModel()
            {
                Title = "Barcelona \u0026 Tenerife",
                Subtitle = "May 25, 2008",
                Description = "Barcelona is an excellent place to discover world-class arts and culture. Bullfighting was officially banned several years ago, but the city remains rich with festivals and events. The sights in Barcelona are second to none. Don’t miss the architectural wonder, Casa Mila—otherwise known as La Pedrera. It’s a modernist apartment building that looks like something out of an expressionist painting. Make your way up to the roof for more architectural surprises. And if you like Casa Mila, you’ll want to see another one of Antoni Gaudi’s architectural masterpieces, Casa Batllo, which is located at the center of Barcelona.\r\nTenerife, one of the nearby Canary Islands, is the perfect escape once you’ve had your fill of the city. In Los Gigantes, life revolves around the marina. Take a boat out in search of bottlenose dolphins and whales. For the able-bodied visitor, take a climb up “Cardiac Hill” to get a breathtaking view—and workout. While you’re in Tenerife, visit Mount Teide. It’s the highest point in Spain and the third-largest volcano in the world.\r\n",
                EventDate = new System.DateTime(2008, 5, 25),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Barcelona_Tenerife.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "United States East Coast Tour 1",
                Description = "Touring the East Coast of the United States provides a massive range of entertainment and exploration. To take things in a somewhat chronological order, best to begin your trip in the north, checking out Boston’s Freedom Trail, Fenway Park, the Statue of Liberty, and Niagara Falls. Bring your raincoat to Niagara Falls, which straddles the boarder between Canada and the United States—the majestic sight might have you feeling misty in every sense of the word. Bring your walking shoes to the Freedom Trail. The 2.5-mile walk will take you on an historical tour of sites relevant to the American Revolution. When you visit Fenway Park, you might be wise to bring a helmet. With fly balls that average a speed of 100 miles per hour, you can never be too safe. Bring a healthy set of lungs to the Statue of Liberty and remember to make an advanced reservation if you’d like to climb the stairs to Lady Liberty’s crown. Finish up your tour at the south end of the coast with Kennedy Space Center in Florida and be sure to bring the kids. Everyone will get the chance to touch an authentic moon rock and stand under the largest rocket ever flown.",
                Subtitle = "Aug 11, 2009",
                EventDate = new System.DateTime(2009, 8, 11),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/United_States_East_Coast_tour_1.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Malta, a Country of Knights",
                Subtitle = "Jun 15, 2008",
                Description = "Home of the oldest-known human structures in the world, the Maltese archipelago is best described as an open-air museum. Malta, the biggest of the seven Mediterranean islands, is the cultural center of the three largest—only three islands that are fully inhabited.  If you’re into heavy metal—swords, armor and other medieval weaponry—you’ll love the Grandmaster’s Palace. It houses a magnificent collection of ornate battle gear. Visit the National Museum of Archaeology to see a spectacular range of artifacts dating back to Malta’s Neolithic period (5000 BC). And for some fresh air and picturesque views, be sure not to miss the Lower Barrakka Gardens. It’s a particularly idea place to take in the magnificent view of the Grand Harbour. Last, but not least, don’t miss the Church of St. Catherine of Alexandria. This recently restored church is an ideal place to see Mattia Preti’s refined style up close.",
                EventDate = new System.DateTime(2008, 6, 15),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Malta_a_country _of_knights.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Wonders of Italy",
                Subtitle = "Jul 6, 2008",
                Description = "The Italian Republic is a history lover’s paradise with thousands of museums, churches and archaeological sites dating back to Roman and Greek times. Visitors will also find a hub for fashion and culture unlike anywhere else in the world. Explore Ancient history in Rome at the Colosseum and Rome’s Ruins. Rome’s greatest gladiator arena has history of unimaginable violence—games that would last 100 days in some cases and involve the slaughter of up to 10,000 animals—but today, it is one of the most majestic sites for Italian tourism. Take a trip to the Sistine Chapel in Vatican City where Michelangelo’s Genesis (Creation), commissioned by Pope Julius II and painted by Michelangelo between 1508 and 1512, attracts droves of visitors each year. Take a waterbus tour of the Grand Canal and stop along the way for a bite to eat and some shopping. Take in the most famous of the city’s churches and one of the best known examples of the Italo-Byzantine architecture, the Basilica of Saint Mark, which lies at the eastern end the Piazza San Marco, adjacent and connected to the Doge’s Palace. And don’t miss the Duomo of Florence.",
                EventDate = new System.DateTime(2008, 7, 6),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Wonders_of_Italy.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "The Best of Western Europe",
                Description = "Tour the best of Western Europe and take in the sights of Munich, Frankfurt, Meinz, Bruxel, Amsterdam, and Vienna along the way. Discover the amazing world of plants at Frankfurt Palmengarten, the botanical gardens in Frankfurt. The Frankfurt Palmengarten is home to 50 acres of tropical trees, orchids and ferns. Stop along the Frankfurt Bridge, affectionately referred to as the Love Bridge, and attach a padlock to the bridge before throwing the key into the river Main. Such is the tradition of love-struck visitors. Visit the Triumphal Arch Brussels. The Arch was planned for the world exhibition of 1880 and was meant to commemorate the 50th anniversary of the independence of Belgium. However, the construction took longer than expected and was completed just in time for the nations 75th anniversary of independence. Don’t miss Vienna’s natural history museum—one of the oldest, largest and most noteworthy natural history museums in the world. Last, but not least, don’t miss the Nymphenburg Palace in Munich. It’s Baroque masterpiece and an architecture lover’s dream.",
                Subtitle = "Feb 27, 2007",
                EventDate = new System.DateTime(2007, 2, 27),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/The_Best_of_Western_Europe.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "UNESCO Sites in Bulgaria",
                Subtitle = "Mar 13, 2009",
                Description = "Bulgaria is located in the heart of the Balkans, sharing boarders with Serbia, Macedonia, Romania, Greece and Turkey. Visitors will be greeted by a unique blend of enchanting monasteries, friendly people and old-world charm. Bulgaria has a democratic government and is one of the oldest states in Europe. Its Black Sea coast draws tourists all year long. \r\n\r\nDon’t miss the frescos at Rila Monastery. This mesmerizing monastery is named after its founder, the hermit Ivan of Rila and has a style unlike any other monastery on the globe. \r\nDuring your stay, you will also want to check out the Alexander Nevsky Cathedral. This Bulgarian Orthodox cathedral is built in Neo-Byzantine style and located in the heart of Sophia.\r\nOutside the city, near the village of Madara, the Madara Rider rock relief carving is a must-see. This mysterious piece of art dates back to 710 AD.\r\nLastly, be sure to see the Basilica of the Holy Mother of God Eleusa and the Church of St. George while you’re here. \r\n",
                EventDate = new System.DateTime(2009, 3, 13),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/UNESCO_sites_in_Bulgaria.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "India, Golden Triangle Khajuraho and Varanasi",
                Subtitle = "Apr 23, 2010",
                Description = "On your visit to India, enjoy the majesty of palaces and opulent architecture. Along your journey, don’t miss the Gateway of India, built to commemorate the power of the British Empire. Visit the great mosque of Old Delhi, India’s largest mosque, with a courtyard large enough to hold a mind-blowing 25,000 devotees. Of course, no trip to India would be complete without taking the time to visit one of the Seven Wonders of the World, the Taj Mahal. The moods of the Taj Mahal vary from dawn to dusk and the morning is recommended as the most alluring time to visit. Watch the color of its sweeping marble surfaces change from soft gray and yellow to pearly cream and sparkling white and experience the symbolic presence of Allah. Before your trip is done, take an elephant ride outside the Amber Fort. These rides are very popular, so those interested in taking one will need to arrive very early in the morning to ensure they don’t get caught in a long line and miss the chance.",
                EventDate = new System.DateTime(2010, 4, 23),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/India_Golden_Triangle_Khajuraho_and_Varanasi.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Highlights of South Africa",
                Subtitle = "Nov 13, 2012",
                Description = "Africa provides some of the most epic wildlife diversity on the planet. Not many vacations involve sleeping in close quarters with lions, leopards, elephants, Cape buffaloes, black rhinos, cheetahs, giraffes and hippos. But South Africa is unique in the fact that it has so much unspoiled lands—like the Featherbed Private Nature Reserve at the western head of Kynysna. It’s one of South Africa’s Natural Heritage Sites that can only be reached by ferry. Kruger National Park, a nature preserve in the northeastern corner of South Africa, is 5 million acres. It’s not a zoo so you aren’t guaranteed to see certain animals at certain times. But it’s the lack of predictability that makes a safari so magical. For a more urban experience, walk the Nelson Mandela Bridge and visit the Apartheid Museum in Johannesburg.",
                EventDate = new System.DateTime(2012, 11, 13),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Grand_tour_of_France.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Costa Rican Treasures",
                Subtitle = "Feb 13, 2013",
                Description = "Whether you’re a surfing enthusiast or just interested in taking an exotic adventure, Costa Rica offers a wide variety of adventuring options. Tour the Tarcoles River to see some major crocodile action from the safety of a boat. The Tarcoles has one of the highest populations of crocodiles in the world with 25 crocodiles per square kilometer. Prefer flowers to flesh-chomping wildlife? Make a day of orchid sniffing. Learn all about these enchanting plants at the Orchid Botanical Garden. You’ll get the chance to visit the orchid lab where they create most of the flowers on the property. At Barra Honda National Park, visitors can explore a system of limestone caves. Bats live there so don’t be afraid if you see one—or 5,000. Last but not least, be sure to check out the Poas Volcano. It may be the most convenient volcano exploration you’ll ever do. You can drive right to the visitor’s center and take a mere 15-minute walk to the main crater.",
                EventDate = new System.DateTime(2013, 2, 13),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Costa_Rican_Treasures.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Brazil and Argentina Iguazu Falls",
                Subtitle = "Apr 13, 2013",
                Description = "With a population over 200 million, the Federative Republic of Brazil is the fifth most populous country in the world, and Rio de Janeiro is its largest city. Vibrating to the alluring sounds of samba, Rio’s residents, known as cariocas, are examples of how to live well. From the renowned beaches of Copacabana and Ipanema to the tops of scenic outlooks of Corcovado and Pão de Açúcar to the dance halls, bars and open-air cafes that give the city its life, cariocas live for the moment without a care in the world. Visitors visit Rio to get a taste of this lifestyle which balances the city scene with natural beauty of the beaches and rainforests, including Prainha and Tijuca respectively.  \r\nRio also juxtaposes a spectacular landscape with a gritty urban scene. Rio d Janeiro is a crime-ridden city, but much can be done to ensure a safe and enjoyable visit provided basic precautions are observed. There are many residents—native and otherwise—that wouldn’t consider living anywhere else. Rio is a great destination for travelers seeking a vibrant cultural experience. \r\n",
                EventDate = new System.DateTime(2013, 4, 13),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Brazil_Argentina_Iguazu_Falls.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Cuba Paradise Island",
                Subtitle = "Jun 16, 2013",
                Description = "Cuba provides a unique travel destination that is equal parts relaxation and education. You’ll find beautiful beaches, rum and some incredible and historically significant locations. Dubbed, “Pearl of the South”, Cienfuegos was originally founded in 1819 as a settlement by French emigrants from Bordeaux and Louisiana. Rum-drinking men and sundrenched women made this beach town their home. The sprawling white sand beaches of Varadero provide plenty of real estate a broad range of resorts, from family-friendly to all-inclusive and everything in between. History lovers won’t want to miss the opportunity to visit Freedom Square (Plaza de la Revolucion), a square in Havana, Cuba. Freedom Square is the largest city square in the world. And last, but not least, take an educational tour and learn all the interesting facts and details about how rum is made. An expert guide will explain the whole process behind rum making and a cute model train set will help illustrate the layout of the distillery.",
                EventDate = new System.DateTime(2013, 6, 16),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Cuba_Paradise_Island.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Egypt Explorer",
                Subtitle = "Apr 12, 2014",
                Description = "Get ready to feel small. Exploring Egypt will put you face-to-face with the ancient Egyptian civilization and their colossal structures—awe-inspiring monuments to the pharos and the gods. Egypt is best known for the Great Pyramids at Giza. The three pyramids—Cheops, Khafre and Menakaure—and the Sphinx are majestic icons of Egypt. However, there are actually over 100 pyramids in Egypt, many of which remain relatively unknown to anyone who is not an ancient Egypt enthusiast. There are tons of temples and ruins to discover and some can only be reached via watercraft. A general rule of thumb is to join a group tour. This will reduce the hassle of negotiating taxi rates and help you fend off solicitors once you reach your destination. You’ll want to check on travel advisories to be sure that you’re travel plans are well timed so that you can enjoy this amazing country to its full potential.",
                EventDate = new System.DateTime(2014, 4, 12),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Egypt_Explorer.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "England, Scotland \u0026 Wales",
                Subtitle = "Nov 23, 2014",
                Description = "Fancy a proper holiday? Well you’ve come to the right place. This city has a lot to do so make a plan if you want to experience all that classic London has to offer. Take a walk across the River Thames on the Millennium steel-suspension footbridge and peruse the fine art at the Tate Modern. Jump into the London Eye and ride it to the top of the city, an insane 135 meters above the river below. Keep the day going by sauntering over to the iconic parliament buildings and saying hello to Big Ben. Make your way to Camden for a little vintage shopping and a relaxing meal or drink. If it’s your first time visiting, you might want to hop on a double decker bus, snap a photo in a telephone booth or try to get the palace guards to crack a smile—because that’s just what people do when they visit London for the first time. ",
                EventDate = new System.DateTime(2014, 11, 23),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/England_Scotland_Wales.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Golden Myanmar",
                Subtitle = "May 12, 2015",
                Description = "Myanmar is home to some of the most sacred places on Earth for Buddhists. Multiple pagodas (temples) house strands of Buddha’s hair. Visit the Taungkalat shrine, home to 37 Mahagiri Nats—animist spirit entities—once so important to the country’s early kings that they would consult the Nats before commencing their reign. You’ll have to climb 777 steps to reach it and you’ll make the journey without any shoes or socks. Tradition is important to the people here in Myanmar. Evidence can be seen in the pious devotees performing deeds of religious merit outside the pagodas. You’ll want to remember to dress conservatively when visiting a temple and remove your shoes and socks before entering a sacred space. A recurring theme you’ll notice is lots of opulent “bling” and gilded spires jetting into the sky. Generally speaking, the cost of your trip will be low but tourist are heavily taxed by the government, so a hotel with extremely modest accommodations might cost you as much as $25 a night.  ",
                EventDate = new System.DateTime(2015, 5, 12),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Golden_Myanmar.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Imperial China",
                Subtitle = "Jul 12, 2015",
                Description = "The ancient sights of China are otherworldly. From the Terracotta Army to the cave carvings at Dragon Gate, the immensity of these Chinese attractions is matched only by the diligence in their details. As you travel down the Yi River, the Great Wall, or enter the archeological excavation of 7,000 life-sized warriors and horses created to guard Qin Shi Huang in the afterlife, you may get the feeling that your travels have leapt beyond the geographical—you may feel as though you have traveled through time. \r\nOne of the less whimsical aspects of your travels will take place in the bathroom. Don’t expect toilet paper to be provided. Be sure to carry your own supplies. Similarly, you’ll want to download a language app to help with translation. If you find yourself in a jam, look for a young person to help you translate. Students under 25-years old are most likely to speak English in addition to Mandarin. \r\n",
                EventDate = new System.DateTime(2015, 7, 12),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Imperial_China.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Kenya",
                Subtitle = "Apr 23, 2016",
                Description = "Adventuring through Kenya is no day at the beach. But those willing to brave this raw and wild area of the world will be rewarded with sights and experiences that will last a lifetime. The Great Rift Valley is home to some pretty unique creatures so don’t be surprised if you have moments in which you question whether you are in fact awake or actually dreaming. If you venture to Kenya between July and October, you will be lucky enough to witness one of nature’s biggest wildlife spectacles, the Great Migration. Catch the wildebeests crossing the river from a hot-air balloon while you sip Champaign and don’t be alarmed if you spot a wild lion, leopard or cheetah down below. Take a hike at Mount Kilimanjaro, the tallest freestanding volcano on Earth at a staggering four miles high. Don’t worry if you can’t make it to the snow-capped summit, only about 50 percent of hikers are able to reach the top.",
                EventDate = new System.DateTime(2016, 4, 23),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Kenya.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "United States East Coast Tour 2",
                Subtitle = "Apr 23, 2017",
                Description = "The Big Apple is a living city, perhaps more so than any other city on Earth. When people come to New York, they fall in love. Not with some local person, restaurant, building, or bar—they fall in love with the city as a whole. It’s easy to see why when you step back and examine the endless variety of life NYC has to offer. It’s almost like a bag filled with hundreds of Broadway sets exploded and all the charming pieces of this city just fell right into place. A twilight stroll across the Brooklyn Bridge, an afternoon of kite flying (or picnicking) in Central Park, a Broadway show or just a couple hours of wandering through Greenwich Village and you’ll be well on your way to NYC infatuation. Don’t expect to see it all in one trip. That will only leave you feeling exhausted and unsuccessful. Chances are, you’ll want to return soon anyway. This tour packs another city you wouldn’t want to miss – Washington D.C. Prepare to be fully captivated by the Nation\u0027s Capitol seen at night and the breathtaking views of the national monuments and federal buildings flooded in lights. The US Capitol Building, the Kennedy Center, the Washington Monument and the Federal Triangle are just a tiny part of everything Washington has to offer.  ",
                EventDate = new System.DateTime(2017, 4, 23),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/United_States_East_Coast_tour_2.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Spectacular Highlights of Turkey and Greece",
                Subtitle = "Jun 12, 2023",
                Description = "Turkey and Greece—two countries filled with ancient history and breathtaking scenery—make the perfect combo for a luxurious vacation with soul. Istanbul is coated in a texture of beautiful details, giving visitors ornate and tasty souvenirs to take home after their visit. The Eminonu quarter of the Faith district is home to the Spice Bazaar, one of the largest bazaars in the city. Try before you buy and do as the locals do in order to get the most value out of your visit. There will be lots to choose from and you might have trouble differentiating between the high- and low-quality shops otherwise. Greece is, of course, filled with architectural marvels including the Erechtheum, an iconic temple in Athens. The Porch of the Maidens is as distinctive today as it was when it was completed in 406 BC. Ladies, bring a scarf to cover your hair if you visit a mosque. Or, better yet, buy one during your travels to remember your vacation by.",
                EventDate = new System.DateTime(2023, 6, 12),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/Spectacular_Highlights_of_Turkey_and_Greece.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "The Best of Japan",
                Subtitle = "Oct 12, 2015",
                Description = "Japan consists of four major islands (Honshu, Hokkaido, Kyushu and Shikoku) and over 4,000 smaller islands, all full of culture, history and natural beauty. The Sea of Japan separates the Japanese archipelago from the Asian continent and its closest neighbors, China, Korea and Russia. Japan’s population of 126 million are the life force of a nation where modern technology abuts deep and enduring cultural traditions. From castles, gardens and temples to cities, mountains and ocean wonders, Japan offers a diverse and secure vacation for visitors the world over. Comprising 23 special wards, 26 cities, 5 towns and 8 villages, Tokyo is the political, economic and cultural center of Japan. Fuji is surrounded by the Ashitaka mountain range, within sight of the majestic Mount Fuji to the north, and works hard to preserve the beauty and natural surroundings of the city. Explore the ocean sports, mountain peaks, nightlife and ancient mysteries that are Japan.",
                EventDate = new System.DateTime(2015, 10, 12),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/The_best_of_Japan.jpg" }
                }
            });

            events.Add(new TimelineEventModel()
            {
                Title = "The Best of Central Europe",
                Subtitle = "Oct 11, 2024",
                Description = "On your journey through the culturally rich countries of Central Europe, you’ll find a wide variety of sights and experiences. There is a world of history in Germany, the Czech Republic, Slovakia, and Hungary, and lots to be learned along the way. Many attractions will provide a first-hand look at the sites where some of our world’s most defining moments have taken place—both joyous and tragic. Visit the remains of the Berlin Wall and learn more about the somewhat recent conflicts that tore Germany in two—and the reunification that followed. In Prague, take a lighter look at our recent history with a visit to the architecturally mesmerizing “Dancing House” designed by Croatian-Czech architect, Vlado Milunic and Canadian-American architect, Frank Gehry. Be sure to call ahead and find out if you need an appointment as some of the most historical landmarks can become busy and require reservations for full access to the building or site.",
                EventDate = new System.DateTime(2024, 10, 11),
                Images = new List<TimelineEventModelImage>() {
                    new TimelineEventModelImage() { src = "../content/web/timeline/images/The_Best_of_Central_Europe.jpg" }
                }
            });

            return Json(events, JsonRequestBehavior.AllowGet);
        }

    }
}
