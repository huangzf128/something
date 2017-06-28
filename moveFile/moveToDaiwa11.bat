rem /I コピー先のディレクトリが存在しない場合は新規にディレクトリを作成する
rem /E ファイルが存在しなくてもディレクトリごとコピーする 

xcopy /i /e D:\workspace\DAIWA\src D:\workspace\DAIWA11\src
xcopy /i /e /-Y /EXCLUDE:excludeList.txt D:\workspace\DAIWA\WebContent D:\workspace\DAIWA11\WebContent