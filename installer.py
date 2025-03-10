import os
script_dir = os.path.dirname(os.path.abspath(__file__))
util_dir = os.path.join(script_dir, "util")
installver = int(input("Which DLL collection do you want to install?\n1 = DirectX 9\n2 = DirectX 11\n3 = DirectX 12\n4 = VCRedist\n"))
if installver == 1:
    os.startfile(os.path.join(util_dir, "dx9installer.bat"))
elif installver == 2:
    os.startfile(os.path.join(util_dir, "dx11installer.bat"))
elif installver == 3:
    os.startfile(os.path.join(util_dir, "dx12installer.bat"))
elif installver == 4:
    os.startfile(os.path.join(util_dir, "vcredistinstaller.bat"))
