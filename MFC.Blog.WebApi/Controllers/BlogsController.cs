using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MFC.Blog.Business.Interfaces;
using MFC.Blog.DTO.DTOs.BlogDtos;
using MFC.Blog.WebApi.Enums;
using MFC.Blog.WebApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace MFC.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllSortedByPostedTimeAsync()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDto>(await _blogService.FindByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
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

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromForm] BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
            {
                return BadRequest("Geçersiz ad");
            }
            var uploadModel = await UploadFileAsync(blogUpdateModel.Image, "image/jpeg");
            if (uploadModel.UploadState == UploadState.Success)
            {
                var uptadedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                uptadedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                uptadedBlog.Description = blogUpdateModel.Description;
                uptadedBlog.Title = blogUpdateModel.Title;
                uptadedBlog.ImagePath = uploadModel.NewName;
                await _blogService.UpdateAsync(uptadedBlog);
                return NoContent();
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {

                var uptadedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                uptadedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                uptadedBlog.Description = blogUpdateModel.Description;
                uptadedBlog.Title = blogUpdateModel.Title;
                await _blogService.UpdateAsync(uptadedBlog);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }

        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)//Route dan gelen id mapleneecek
        {
            await _blogService.RemoveAsync(new Entities.Concrete.Blog { Id = id });
            return NoContent();
        }
    }
}
