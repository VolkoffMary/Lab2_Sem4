using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5.Controllers;
using Lab5.Models;
using Xunit;

namespace Lab5.Tests
{
    public class UnitTest
    {
        private readonly CatalogueAPIContext _context = new CatalogueAPIContext();
        [Fact]
        public async Task GetAllSizes_ShouldReturnAllSizes()
        {
            var controller = new SizesController(_context);
            var testSizes = GetTestSizes();
            foreach (var item in testSizes)
            {
                _context.Sizes.Add(item);   
            }
            _context.SaveChanges();

            var result = await controller.GetSizes();
            var list = result.Value;
            Assert.Equal(testSizes.Count, list.Count);
        }
        
        [Fact]
        public async Task GetSize_ShouldReturnCorrectSize()
        {
            var controller = new SizesController(_context);
            var testSizes = GetTestSizes();
            foreach (var item in testSizes)
            {
                _context.Sizes.Add(item);
            }
            _context.SaveChanges();


            var result = await controller.GetSize(4);
            var data = result.Value.Name;
            Assert.NotNull(result);
            Assert.Equal(testSizes[3].Name, data);
        }

        [Fact]
        public async Task GetSize_ShouldNotFindSize()
        {
            var controller = new SizesController(_context);
            var testSizes = GetTestSizes();
            foreach (var item in testSizes)
            {
                _context.Sizes.Add(item);
            }
            _context.SaveChanges();

            var result = await controller.GetSize(99);
            Assert.IsNotType<Size>(result.Value);
        }

        [Fact]
        public async Task PutSize()
        {
            var controller = new SizesController(_context);
            var size = new Size { Id = 1, Name = "Demo1" };

            await controller.PutSize(1, size);
            var result = await controller.GetSize(1);
            Assert.Equal(size, result.Value);
        }

        [Fact]
        public async Task PostSize()
        {
            var controller = new SizesController(_context);
            var size = new Size { Id = 1, Name = "Demo1" };

            await controller.PostSize(size);
            var result = await controller.GetSizes();

            Assert.Equal(true, result.Value.Contains(size));
        }

        [Fact]
        public async Task DeleteSize()
        {
            var controller = new SizesController(_context);
            var testSizes = GetTestSizes();
            foreach (var item in testSizes)
            {
                _context.Sizes.Add(item);
            }
            _context.SaveChanges();
            var Size = await controller.GetSize(1);
            await controller.DeleteSize(1);
            var result = await controller.GetSizes();
            var list = result.Value;
            Assert.Equal(false, list.Contains(Size.Value));
        }

        private List<Size> GetTestSizes()
        {
            var testSizes = new List<Size>();
            testSizes.Add(new Size { Id = 1, Name = "Demo1" });
            testSizes.Add(new Size { Id = 2, Name = "Demo2" });
            testSizes.Add(new Size { Id = 3, Name = "Demo3" });
            testSizes.Add(new Size { Id = 4, Name = "Demo4" });

            return testSizes;
        }
    }
}