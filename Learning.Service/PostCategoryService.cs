using Learning.Data.Infrastructure;
using Learning.Data.Repositories;
using Learning.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service
{
    public interface IPostCategoryServie
    {
        void Add(PostCategory postCategory);
        void Update(PostCategory postCategory);
        void Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentId(int parentId);
        PostCategory GetById(int id);
    }
    public class PostCategoryService: IPostCategoryServie
    {
        IPostCategoryRepository _postcategoryRepository;
        IUnitOfWork _unitOfWork;
        public PostCategoryService(IPostCategoryRepository postcategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postcategoryRepository = postcategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(PostCategory postCategory)
        {
            _postcategoryRepository.Add(postCategory);
        }

        public void Delete(int id)
        {
            _postcategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postcategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return _postcategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postcategoryRepository.GetSingleById(id);
        }

        public void Update(PostCategory postCategory)
        {
            _postcategoryRepository.Update(postCategory);
        }
    }
}
