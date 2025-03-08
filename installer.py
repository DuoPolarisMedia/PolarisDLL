import os
installver=int(input("Which DLL collection do you want to install?\n1 = DirectX 9\n2 = DirectX 11\n3 = DirectX 12\n4 = VCRedist"))
if installver == 1:
    os.startfile("util/dx9installer.bat")
elif installver == 2:
    os.startfile("util/dx11installer.bat")
elif installver == 3:
    os.startfile("util/dx12installer.bat")
elif installver == 4:
    os.startfile("util/vcredistinstaller.bat")