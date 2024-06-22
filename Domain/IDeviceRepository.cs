using Domain.Entities;

namespace Domain
{
    public interface IDeviceRepository
    {
        List<CameraEntity> GetDevicesByName(string name);
        List<CameraEntity> GetDevices();
    }
}
