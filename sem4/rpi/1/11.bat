@echo off
:start
echo you at start
echo 1 - to 11
echo 2 - to 12
set /p var=input:
if "%var%" == "1" goto 11
if "%var%" == "2" goto 12
:11
echo you at 11
echo 1 - to 21(exit)
echo 2 - to 22
set /p var=input:
if "%var%" == "1" goto 21
if "%var%" == "2" goto 22
	:21
	goto exit
	:22
	echo you at 22
	echo 1 - to 31
	set /p var=input:
	if "%var%" == "1" goto 31
:12
echo you at 12
echo 1 - to 23(exit)
echo 2 - to 31
set /p var=input:
if "%var%" == "1" goto 23
if "%var%" == "2" goto 31
	:23
	goto exit
		:31
		echo you at 31
		echo 1 - to 41(exit)
		echo 2 - to 42
		set /p var=input:
		if "%var%" == "1" goto 41
		if "%var%" == "2" goto 42
			:41
			goto exit
			:42
			echo you at 42
			echo 1 - to start
			set /p var=input:
			if "%var%" == "1" goto start
			goto start
:exit