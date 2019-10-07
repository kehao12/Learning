﻿using Learning.Data.Infrastructure;
using Learning.Data.Repositories;
using Learning.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Learning.Service
{
    public interface IPostService
    {

        Post Add(Post Post);

        void Update(Post Post);

        Post Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAll(string keyword);

        IEnumerable<Post> GetAllByParentId(int parentId);

        IEnumerable<Post> GetLastest(int top);

        IEnumerable<Post> GetHotPost(int top);

        Post GetById(int id);

        void Save();
    }
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }
        public Post Add(Post Post)
        {
            return _postRepository.Add(Post);
        }

        public Post Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public IEnumerable<Post> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _postRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
                return _postRepository.GetAll();

        }

        public IEnumerable<Post> GetAllByParentId(int parentId)
        {
            return _postRepository.GetMulti(x => x.Status && x.CategoryID == parentId);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public IEnumerable<Post> GetLastest(int top)
        {
            return _postRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Post> GetHotPost(int top)
        {
            return _postRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);

        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post Post)
        {
            _postRepository.Update(Post);
        }
    }
}
