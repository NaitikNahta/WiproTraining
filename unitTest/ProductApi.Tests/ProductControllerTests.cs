using Xunit;
using ProductApi.Controllers;
using Microsoft.AspNetCore.Mvc;

public class ProductControllerTests
{
    [Fact]
    public void Get_InvalidId_ReturnsBadRequest()
    {
        var controller = new ProductController();

        var result = controller.Get(0);

        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public void Get_ValidId_ReturnsOk()
    {
        var controller = new ProductController();

        var result = controller.Get(1);

        Assert.IsType<OkObjectResult>(result);
    }
}