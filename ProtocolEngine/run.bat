@echo off
set current_path=%cd%
set output_path=%current_path%\..\..\Procotol_Gen\
set ref_path=%current_path%\Referenced
set scripts_path=%current_path%\Scripts
start ProtocolEngine.exe %output_path% %ref_path% %scripts_path%