using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MySchoolWebSite.Models.Abstract;
using MySchoolWebSite.Models.Dapper;
using MySchoolWebSite.Service;

namespace MySchoolWebSite.Domains
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IClassRepository, ClassRepository>(provider =>
                new ClassRepository(Config.ConnectionString));
            services.AddTransient<IStudentRepository, StudentRepository>(provider =>
                new StudentRepository(Config.ConnectionString));
            services.AddTransient<ISubjectRepository, SubjectRepository>(provider =>
                new SubjectRepository(Config.ConnectionString));
            services.AddTransient<IRatingRepository, RatingRepository>(provider =>
                new RatingRepository(Config.ConnectionString));
            services.AddTransient<ILearningProgramRepository, LearningProgramRepository>(provider =>
                new LearningProgramRepository(Config.ConnectionString));
            services.AddTransient<IUserRepository, UserRepository>(provider =>
                new UserRepository(Config.ConnectionString));
            services.AddTransient<IRoleRepository, RoleRepository>(provider =>
                new RoleRepository(Config.ConnectionString));
            return services;
        }
    }
}
