@echo off
:start
echo 1 - выход
echo 2 - далее
set /p var=Вариант:
if "%var%" == "2" goto next
if "%var%" == "1" goto exit
:next
echo 1 - выход
echo 2 - сначала
set /p var=Вариант:
if "%var%" == "2" goto start
if "%var%" == "1" goto exit
:exit
