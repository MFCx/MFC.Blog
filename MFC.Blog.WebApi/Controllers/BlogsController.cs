using System;
using AutoMapper;
using MFC.Blog.Business.Interfaces;
using MFC.Blog.DTO.DTOs.BlogDtos;
using MFC.Blog.DTO.DTOs.CategoryBlogDtos;
using MFC.Blog.Entities.Concrete;
using MFC.Blog.WebApi.CustomFilters;
using MFC.Blog.WebApi.Enums;
using MFC.Blog.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFC.Blog.DTO.DTOs.CategoryDtos;
using MFC.Blog.DTO.DTOs.Comment;


namespace MFC.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;

        public BlogsController(IBlogService blogService, IMapper mapper, ICommentService commentService)
        {
            _blogService = blogService;
            _mapper = mapper;
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllSortedByPostedTimeAsync()));
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Entities.Concrete.Blog>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDto>(await _blogService.FindByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Create([FromForm] BlogAddModel blogAddModel)
        {
            var uploadModel = await UploadFileAsync(blogAddModel.Image, "image/jpeg");
            if (uploadModel.UploadState == UploadState.Success)
            {
                blogAddModel.ImagePath = uploadModel.NewName;
                await _blogService.AddAsync(_mapper.Map<Entities.Concrete.Blog>(blogAddModel));
                return Created("", blogAddModel);
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                await _blogService.AddAsync(_mapper.Map<Entities.Concrete.Blog>(blogAddModel));
                return Created("", blogAddModel);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }

        }

        //[HttpPut("{id}")]
        //[Authorize]
        //[ValidModel]
        //[ServiceFilter(typeof(ValidId<Entities.Concrete.Blog>))]
        //public async Task<IActionResult> Update(int id, [FromForm] BlogUpdateModel blogUpdateModel)
        //{
        //    if (id != blogUpdateModel.Id)
        //    {
        //        return BadRequest("Geçersiz ad");
        //    }
        //    var uploadModel = await UploadFileAsync(blogUpdateModel.Image, "image/jpeg");
        //    if (uploadModel.UploadState == UploadState.Success)
        //    {
        //        var uptadedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
        //        uptadedBlog.ShortDescription = blogUpdateModel.ShortDescription;
        //        uptadedBlog.Description = blogUpdateModel.Description;
        //        uptadedBlog.Title = blogUpdateModel.Title;
        //        uptadedBlog.ImagePath = uploadModel.NewName;
        //        await _blogService.UpdateAsync(uptadedBlog);
        //        return NoContent();
        //    }
        //    else if (uploadModel.UploadState == UploadState.NotExist)
        //    {

        //        var uptadedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
        //        uptadedBlog.ShortDescription = blogUpdateModel.ShortDescription;
        //        uptadedBlog.Description = blogUpdateModel.Description;
        //        uptadedBlog.Title = blogUpdateModel.Title;
        //        await _blogService.UpdateAsync(uptadedBlog);
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return BadRequest(uploadModel.ErrorMessage);
        //    }

        //}

        [HttpPut("{id}")]
        [Authorize]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Entities.Concrete.Blog>))]
        public async Task<IActionResult> Update(int id, [FromForm] BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
                return BadRequest("geçersiz id");

            var uploadModel = await UploadFileAsync(blogUpdateModel.Image, "image/jpeg");

            if (uploadModel.UploadState == UploadState.Success)
            {
                var updatedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);

                updatedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                updatedBlog.Title = blogUpdateModel.Title;
                updatedBlog.Description = blogUpdateModel.Description;
                updatedBlog.ImagePath = uploadModel.NewName;


                await _blogService.UpdateAsync(updatedBlog);
                return NoContent();
            }


            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                var updatedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                updatedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                updatedBlog.Title = blogUpdateModel.Title;
                updatedBlog.Description = blogUpdateModel.Description;

                await _blogService.UpdateAsync(updatedBlog);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidId<Entities.Concrete.Blog>))]
        public async Task<IActionResult> Delete(int id)//Route dan gelen id mapleneecek
        {
            await _blogService.RemoveAsync(await _blogService.FindByIdAsync(id));
            return NoContent();
        }
        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> AddToCategory(CategoryBlogDto categoryBlogDto)//Route dan gelen id mapleneecek
        {
            await _blogService.AddToCategoryAsync(categoryBlogDto);
            return Created("", categoryBlogDto);
        }


        [HttpDelete("[action]")]

        public async Task<IActionResult> RemoveFromCategory(CategoryBlogDto categoryBlogDto)//Route dan gelen id mapleneecek
        {
            await _blogService.RemoveFromCategoryAsync(categoryBlogDto);
            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {

            return Ok(await _blogService.GetAllByCategoryIdAsync(id));
        }
        //blogs/1/categories
        [HttpGet("{id}/[action]")]
        [ServiceFilter(typeof(ValidId<Entities.Concrete.Blog>))]
        public async Task<IActionResult> GetCategories(int id)
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _blogService.GetCategoriesAsync(id)));
        }
        [HttpGet("[action]")]
        [ServiceFilter(typeof(ValidId<Entities.Concrete.Blog>))]
        public async Task<IActionResult> GetLastFive()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetLastFiveAsync()));
        }

        [HttpGet("{id}/[action]")]
        public async Task<IActionResult> GetComments([FromRoute] int id, [FromQuery] int? parentCommentId)
        {
            return Ok(_mapper.Map<List<CommentListDto>>(await _commentService.GetAllWithSubCommentsAsync(id, parentCommentId)));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Search([FromQuery] string sentence)
        {

            var result = _mapper.Map<List<BlogListDto>>(await _blogService.SearchAsync(sentence));
            if (result.Count > 0)
            {
                return Ok(result);
            }

            return BadRequest("Bulunamadı");
        }
        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> AddComment(CommentAddDto commentAddDto)
        {
            commentAddDto.PostedTime = DateTime.Now;
            await _commentService.AddAsync(_mapper.Map<Comment>(commentAddDto));

            return Created("", commentAddDto);

        }
    }
}
