@echo off

call :git

pause
exit /b

:git
	echo %cd%
	git -c "credential.helper=C:/Program\ Files\ \(x86\)/SmartGit/lib/credentials.cmd" -c ssh.variant=plink lfs prune --verify-remote
	echo.
	cd ..
	exit /b