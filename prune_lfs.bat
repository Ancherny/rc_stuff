@echo off

call :git

pause
exit /b

:git
	echo %cd%
	git lfs prune --verify-remote
	echo.
	cd ..
	exit /b