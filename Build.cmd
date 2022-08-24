@echo off
pushd "%~dp0"
powershell Compress-7Zip "bin\Release\net46" -ArchiveFileName "HYDRA.zip" -Format Zip
:exit
popd
@echo on