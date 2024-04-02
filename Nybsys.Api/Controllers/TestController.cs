using Inventory.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Inventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        public TestController()
        {
            
        }

        [HttpPost("data-validation")]
        public async Task<IActionResult> YourAction(ValidationModel model)
        {
            try
            {

            }
            catch (HttpRequestException ex) when (ex.InnerException is OperationCanceledException)
            {
                // Handle timeout exception
            }
            return Ok();
        }
        [HttpPost("getInfo")]
        public IActionResult GetNetworkInfo()
        {
            // Get MAC address
            string macAddress = GetMacAddress();

            // Get IP address
            string ipAddress = GetIpAddress();

            // Return the information in the response
            return Ok(new { MacAddress = macAddress, IpAddress = ipAddress });
        }

        private string GetMacAddress()
        {
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
                    byte[] bytes = physicalAddress.GetAddressBytes();
                    return BitConverter.ToString(bytes).Replace("-", ":");
                }
            }
            return "No MAC Address found";
        }

        private string GetIpAddress()
        {
           // string ipAddress = null;
            string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            return ipAddress ?? "No IP Address found";
        }
    }
}
