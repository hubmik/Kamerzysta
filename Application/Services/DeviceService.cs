using Application.DTO;
using Domain;
using Domain.Entities;

namespace Application.Services
{    
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _cameraRepository;
        public DeviceService(IDeviceRepository cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }
        public IEnumerable<CameraDto> GetAllDevices()
        {
            IEnumerable<CameraDto> cameras = _cameraRepository
                .GetDevices()
                .ConvertAll(x => new CameraDto
            {
                FullName = x.FullName,
                Number = x.Number,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            });

            return cameras;
        }

        private CameraDto EntityToDto(CameraEntity camera)
        {
            return new CameraDto();
        }
    }
}
