using Application.DTO;

namespace Application
{
    public interface IDeviceService
    {
        IEnumerable<CameraDto> GetAllDevices();
    }
}
