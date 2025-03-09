@echo off
:: Ask the user for an installation directory
set "downloadsdir="
set /p "downloadsdir=Enter the directory where you want to install the files: "

:: Resolve full path
for %%I in ("%downloadsdir%") do set "downloadsdir=%%~fI"

:: Ensure the directory exists
if not exist "%downloadsdir%" mkdir "%downloadsdir%"

:: Check if the directory is writable
echo Testing Write Access > "%downloadsdir%\test_write_access.txt"
if not exist "%downloadsdir%\test_write_access.txt" (
    echo ERROR: The directory "%downloadsdir%" is protected or not writable.
    echo Please enter a different directory.
    pause
    exit /b 1
)
del "%downloadsdir%\test_write_access.txt"

:: Check if running as administrator
net session >nul 2>&1
if %errorlevel% neq 0 (
    echo WARNING: This script is not running as Administrator.
    echo If the downloads fail, please restart the script with Admin rights.
    pause
)

:: Change directory to downloads directory
cd /d "%downloadsdir%"

:: Now you can reference or manipulate files in foldertoreference
@echo on

curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_33.dll" --output D3DCompiler_33.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_34.dll" --output D3DCompiler_34.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_35.dll" --output D3DCompiler_35.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_36.dll" --output D3DCompiler_36.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_37.dll" --output D3DCompiler_37.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_38.dll" --output D3DCompiler_38.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_39.dll" --output D3DCompiler_39.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_40.dll" --output D3DCompiler_40.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_41.dll" --output D3DCompiler_41.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_42.dll" --output D3DCompiler_42.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_43.dll" --output D3DCompiler_43.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DCompiler_44.dll" --output D3DCompiler_44.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/d3dcompiler_47.dll" --output d3dcompiler_47.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/d3dcsx_42.dll" --output d3dcsx_42.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/d3dcsx_43.dll" --output d3dcsx_43.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/d3dscache.dll" --output d3dscache.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_24.dll" --output D3DX9_24.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_25.dll" --output D3DX9_25.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_26.dll" --output D3DX9_26.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_27.dll" --output D3DX9_27.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_28.dll" --output D3DX9_28.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_29.dll" --output D3DX9_29.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_30.dll" --output D3DX9_30.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_31.dll" --output D3DX9_31.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_32.dll" --output D3DX9_32.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_33.dll" --output D3DX9_33.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_34.dll" --output D3DX9_34.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_35.dll" --output D3DX9_35.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_36.dll" --output D3DX9_36.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_37.dll" --output D3DX9_37.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_38.dll" --output D3DX9_38.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_39.dll" --output D3DX9_39.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_40.dll" --output D3DX9_40.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_41.dll" --output D3DX9_41.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_42.dll" --output D3DX9_42.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/D3DX9_43.dll" --output D3DX9_43.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/X3DAudio1_7.dll" --output X3DAudio1_7.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/XAPOFX1_5.dll" --output XAPOFX1_5.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/xinput1_1.dll" --output xinput1_1.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/xinput1_2.dll" --output xinput1_2.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/xinput1_3.dll" --output xinput1_3.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/xinput1_4.dll" --output xinput1_4.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/xinput9_1_0.dll" --output xinput9_1_0.dll
curl -o "%downloadsdir%" "https://zephyrgddp.github.io/DLLlib/dlls/dx9/xinputuap.dll" --output xinputuap.dll
pause