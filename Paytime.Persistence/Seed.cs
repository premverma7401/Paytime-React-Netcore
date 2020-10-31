using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Paytime.Domain;

namespace Paytime.Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<UserModel> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<UserModel> {
                    new UserModel {
                        DisplayName = "prem",
                        UserName = "premsager",
                        Email = "prem@test.com",
                        COA = "25-2019-55",
                        FirstName="Prem",
                        LastName="Sager",
                        Contract = ContractType.Casual

                    }, new UserModel {
                        DisplayName = "test",
                        UserName = "test",
                        Email = "test@test.com",
                        COA = "50-2019-55",
                          FirstName="Test",
                        LastName="Account",
                        Contract = ContractType.Parttime

                    }, new UserModel {
                        DisplayName = "aman",
                        UserName = "amanv",
                        Email = "aman@test.com",
                        COA = "75-2019-55",
                          FirstName="Aman",
                        LastName="Verma",
                        Contract = ContractType.Fulltime

                    }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!context.Timesheets.Any())
            {
                var timesheets = new List<WeeklyDataModel>
                 {
                    new WeeklyDataModel {
                        MainSite = "UOA",
                        WeekRange = "25-5-2020 To 31-5-2020",
                        WeekHoursTotal = 50,
                        DaysWorked = 5,
                        DaysOff = 2,
                        CreatedBy="premsager",
                        Created = DateTime.Now,
                        LastModifiedBy="1",
                        DailyData = new List < DailyDataModel >
                        {
                            new DailyDataModel
                             {
                                Day = DateTime.Now,
                                ShiftData = new List < ShiftDataModel >
                                {
                                    new ShiftDataModel
                                    {
                                        SiteName = "UOA Epsom",
                                        StartTime =DateTime.Now,
                                        EndTime = DateTime.Now,
                                        ShiftHourTotal = "8",
                                        ShiftNotes = "No Incident to report",

                                    }
                                }
                            },
                             new DailyDataModel
                              {
                                Day = DateTime.Now,
                                ShiftData = new List < ShiftDataModel >
                                {
                                    new ShiftDataModel
                                     {
                                        SiteName = "UOA Grafton",
                                        StartTime = DateTime.Now,
                                        EndTime = DateTime.Now,
                                        ShiftHourTotal = "10",
                                        ShiftNotes = "3 Incident to report"
                                    }
                                }
                            },
                            new DailyDataModel {
                                Day = DateTime.Now,
                                ShiftData = new List < ShiftDataModel > {
                                    new ShiftDataModel {
                                        SiteName = "UOA Manukau",
                                        StartTime = DateTime.Now,
                                        EndTime = DateTime.Now,
                                        ShiftHourTotal = "12",
                                        ShiftNotes = "1 Incident to report"
                                    },
                                },
                            }, new DailyDataModel {
                                Day = DateTime.Now,
                                ShiftData = new List < ShiftDataModel > {
                                    new ShiftDataModel {
                                        SiteName = "UOA New Market",
                                        StartTime = DateTime.Now,
                                        EndTime = DateTime.Now,
                                        ShiftHourTotal = "12",
                                        ShiftNotes = "All good onsite"
                                    },
                                },
                            }, new DailyDataModel {
                                Day = DateTime.Now,
                                ShiftData = new List < ShiftDataModel > {
                                    new ShiftDataModel {
                                        SiteName = "UOA Tamaki",
                                        StartTime = DateTime.Now,
                                        EndTime = DateTime.Now,
                                        ShiftHourTotal = "10",
                                        ShiftNotes = "No Incident to report"
                                    },
                                },
                            }, new DailyDataModel {
                                Day = DateTime.Now,
                                ShiftData = new List < ShiftDataModel > {
                                    new ShiftDataModel {
                                        SiteName = "UOA Epsom",
                                        StartTime = DateTime.Now,
                                        EndTime = DateTime.Now,
                                        ShiftHourTotal = "8",
                                        ShiftNotes = "No Incident to report"
                                    },
                                },
                            }, new DailyDataModel {
                                Day = DateTime.Now,
                                ShiftData = new List < ShiftDataModel > {
                                    new ShiftDataModel {
                                        SiteName = "Day PC",
                                        StartTime = DateTime.Now,
                                        EndTime = DateTime.Now,
                                        ShiftHourTotal = "12",
                                        ShiftNotes = "Busy Day"
                                    },
                                },
                            }
                        },

                    }
                 };
                context.Timesheets.AddRange(timesheets);
                context.SaveChanges();
            }
        }
    }
}


