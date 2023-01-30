using Cinemachine;

public interface ICameraChanger
{
    void CameraChange();
    CinemachineVirtualCamera VCam { get; }
}

