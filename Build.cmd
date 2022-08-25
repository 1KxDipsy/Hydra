@echo off
pushd "%~dp0"
powershell Compress-7Zip "Source\bin\Release\net46" -ArchiveFileName "HYDRA.zip" -Format Zip
:exit
popd
@echo on
