using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.Services
{
    public interface ICourseCategoryService
    {
        Task<IEnumerable<CourseCategory>> GetAllCourseCategoriesAsync();
    }

    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly ICourseCategoryRepository courseCategoryRepository;

        public CourseCategoryService(ICourseCategoryRepository courseCategoryRepository)
        {
            this.courseCategoryRepository = courseCategoryRepository;
        }
        public async Task<IEnumerable<CourseCategory>> GetAllCourseCategoriesAsync()
        {
            return await courseCategoryRepository.GetAllCourseCategoriesAsync();
        }
    }
}
