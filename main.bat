@echo off
chcp 65001 >nul

echo Which DLL collection do you want to install?
echo 1 = DirectX 9
echo 2 = DirectX 11
echo 3 = DirectX 12
echo 4 = VCRedist
set /p installver=Enter the number: 

if "%installver%"=="1" set "zipurl=https://zephyrgddp.github.io/PolarisDLL/dlls/dx9.zip" & set "zipname=DirectX9.zip"
if "%installver%"=="2" set "zipurl=https://zephyrgddp.github.io/PolarisDLL/dlls/dx11.zip" & set "zipname=DirectX11.zip"
if "%installver%"=="3" set "zipurl=https://zephyrgddp.github.io/PolarisDLL/dlls/dx12.zip" & set "zipname=DirectX12.zip"
if "%installver%"=="4" set "zipurl=https://zephyrgddp.github.io/PolarisDLL/dlls/vcredist.zip" & set "zipname=VCRedist.zip"

if defined zipurl (
    echo Installing archive...
    curl -o "%zipname%" "%zipurl%"
    echo %zipname% is now installed.
) else (
    echo Invalid selection. Exiting.
)

pause
