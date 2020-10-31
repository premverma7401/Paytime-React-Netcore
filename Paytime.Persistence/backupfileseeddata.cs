// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net.Http.Headers;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Identity;
// using Paytime.Domain;

// namespace Paytime.Persistence
// {
//     public class Seed
//     {
//         public static async Task SeedData(DataContext context, UserManager<UserModel> userManager)
//         {
//             if (!userManager.Users.Any())
//             {
//                 var users = new List<UserModel> {
//                     new UserModel {
//                         DisplayName = "prem",
//                         UserName = "premsager",
//                         Email = "prem@test.com",
//                         COA = "25-2019-55",



//                     }, new UserModel {
//                         DisplayName = "test",
//                         UserName = "test",
//                         Email = "test@test.com",
//                         COA = "50-2019-55",

//                     }, new UserModel {
//                         DisplayName = "aman",
//                         UserName = "amanv",
//                         Email = "aman@test.com",
//                         COA = "75-2019-55",

//                     }
//                 };
//                 foreach (var user in users)
//                 {
//                     await userManager.CreateAsync(user, "Pa$$w0rd");
//                 }
//             }
//             if (!context.Timesheets.Any())
//             {
//                 var timesheets = new List<WeeklyDataModel> {
//                     new WeeklyDataModel {
//                         MainSite = "UOA",
//                         WeekRange = "25-5-2020 To 31-5-2020",
//                         WeekHoursTotal = 50,
//                         DaysWorked = 5,
//                         DaysOff = 2,
//                         CreatedBy="premsager",
//                         Created = DateTime.Now,
//                         LastModifiedBy="1",
//                         DailyData = new List < DailyDataModel > {
//                             new DailyDataModel {
//                                 Day = "Monday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Epsom",
//                                         StartTime = "06:30",
//                                         EndTime = "14:30",
//                                         ShiftHourTotal = "8",
//                                         ShiftNotes = "No Incident to report",

//                                     }
//                                 }
//                             }, new DailyDataModel {
//                                 Day = "Tuesday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Grafton",
//                                         StartTime = "08:30",
//                                         EndTime = "18:30",
//                                         ShiftHourTotal = "10",
//                                         ShiftNotes = "3 Incident to report"
//                                     }
//                                 }
//                             },
//                             new DailyDataModel {
//                                 Day = "Wednesday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Manukau",
//                                         StartTime = "10:30",
//                                         EndTime = "22:30",
//                                         ShiftHourTotal = "12",
//                                         ShiftNotes = "1 Incident to report"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Thursday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA New Market",
//                                         StartTime = "08:00",
//                                         EndTime = "20:00",
//                                         ShiftHourTotal = "12",
//                                         ShiftNotes = "All good onsite"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Friday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Tamaki",
//                                         StartTime = "06:30",
//                                         EndTime = "16:30",
//                                         ShiftHourTotal = "10",
//                                         ShiftNotes = "No Incident to report"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Saturday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Epsom",
//                                         StartTime = "06:30",
//                                         EndTime = "14:30",
//                                         ShiftHourTotal = "8",
//                                         ShiftNotes = "No Incident to report"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Sunday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "Day PC",
//                                         StartTime = "05:00",
//                                         EndTime = "17:00",
//                                         ShiftHourTotal = "12",
//                                         ShiftNotes = "Busy Day"
//                                     },
//                                 },
//                             },
//                         }
//                     }, new WeeklyDataModel {
//                         MainSite = "UOA",
//                         WeekRange = "1-7-2020 To 8-7-2020",
//                         WeekHoursTotal = 40,
//                         DaysWorked = 4,
//                           CreatedBy="premsager",
//                         Created = DateTime.Now,
//                         LastModifiedBy="2",
//                         DaysOff = 3,
//                         DailyData = new List < DailyDataModel > {
//                             new DailyDataModel {
//                                 Day = "Monday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "Manukau",
//                                         StartTime = "15:30",
//                                         EndTime = "22:30",
//                                         ShiftHourTotal = "8",
//                                         ShiftNotes = "No Incident to report",

//                                     }
//                                 }
//                             }, new DailyDataModel {
//                                 Day = "Tuesday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "Tamaki",
//                                         StartTime = "08:30",
//                                         EndTime = "20:30",
//                                         ShiftHourTotal = "12",
//                                         ShiftNotes = "3 Incident to report"
//                                     }
//                                 }
//                             },
//                             new DailyDataModel {
//                                 Day = "Wednesday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Manukau",
//                                         StartTime = "18:30",
//                                         EndTime = "22:30",
//                                         ShiftHourTotal = "4",
//                                         ShiftNotes = "11 Incident to report"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Thursday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA New Market",
//                                         StartTime = "08:00",
//                                         EndTime = "20:00",
//                                         ShiftHourTotal = "12",
//                                         ShiftNotes = "All good onsite"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Friday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Tamaki",
//                                         StartTime = "06:30",
//                                         EndTime = "16:30",
//                                         ShiftHourTotal = "10",
//                                         ShiftNotes = "No Incident to report"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Saturday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Epsom",
//                                         StartTime = "06:30",
//                                         EndTime = "14:30",
//                                         ShiftHourTotal = "8",
//                                         ShiftNotes = "No Incident to report"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Sunday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "Day PC",
//                                         StartTime = "05:00",
//                                         EndTime = "17:00",
//                                         ShiftHourTotal = "12",
//                                         ShiftNotes = "Busy Day"
//                                     },
//                                 },
//                             },
//                         }
//                     }, new WeeklyDataModel {
//                         MainSite = "UOA",
//                         WeekRange = "21-4-2020 To 28-4-2020",
//                         WeekHoursTotal = 72,
//                           CreatedBy="amanv",
//                         Created = DateTime.Now,
//                         LastModifiedBy="1",
//                         DaysWorked = 7,
//                         DaysOff = 0,
//                         DailyData = new List < DailyDataModel > {
//                             new DailyDataModel {
//                                 Day = "Monday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "Pukekohe",
//                                         StartTime = "06:30",
//                                         EndTime = "14:30",
//                                         ShiftHourTotal = "8",
//                                         ShiftNotes = "No Incident to report",

//                                     }
//                                 }
//                             }, new DailyDataModel {
//                                 Day = "Tuesday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Grafton",
//                                         StartTime = "08:30",
//                                         EndTime = "18:30",
//                                         ShiftHourTotal = "10",
//                                         ShiftNotes = "3 Incident to report"
//                                     }
//                                 }
//                             },
//                             new DailyDataModel {
//                                 Day = "Wednesday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Manukau",
//                                         StartTime = "10:30",
//                                         EndTime = "22:30",
//                                         ShiftHourTotal = "12",
//                                         ShiftNotes = "1 Incident to report"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Thursday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA New Market",
//                                         StartTime = "08:00",
//                                         EndTime = "20:00",
//                                         ShiftHourTotal = "12",
//                                         ShiftNotes = "All good onsite"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Friday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Tamaki",
//                                         StartTime = "06:30",
//                                         EndTime = "16:30",
//                                         ShiftHourTotal = "10",
//                                         ShiftNotes = "No Incident to report"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Saturday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "UOA Epsom",
//                                         StartTime = "06:30",
//                                         EndTime = "14:30",
//                                         ShiftHourTotal = "8",
//                                         ShiftNotes = "No Incident to report"
//                                     },
//                                 },
//                             }, new DailyDataModel {
//                                 Day = "Sunday",
//                                 ShiftData = new List < ShiftDataModel > {
//                                     new ShiftDataModel {
//                                         SiteName = "Day PC",
//                                         StartTime = "05:00",
//                                         EndTime = "17:00",
//                                         ShiftHourTotal = "12",
//                                         ShiftNotes = "Busy Day"
//                                     },
//                                 },
//                             },
//                         }
//                     },
//                 };
//                 context.Timesheets.AddRange(timesheets);
//                 context.SaveChanges();
//             }

//         }
//     }
// }