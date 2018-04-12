pipeline {
  agent any
  stages {
    stage('Build') {
      parallel {
        stage('Build') {
          steps {
            echo 'Build'
            sh '''"D:\\Unity\\Editor\\Unity.exe" -projectpath 
"C:\\Program Files (x86)\\Jenkins\\workspace\\UnityCommandLine_master-6QYLZI6LZO7LZ4X2BCK6XHHK3NUXXXK3LPPOAGPXHVBBGKGOBB2Q\\UnityCommandLineBuild-master"
-quit -batchmode
-executeMethod "BuildTool.Build"'''
          }
        }
        stage('Bat') {
          steps {
            bat 'ECHO finish'
          }
        }
      }
    }
    stage('Unity') {
      steps {
        echo '"$UNITY_PATH" -projectPath "$PROJECT_PATH" -logFile "$LOG_PATH"  -quit -batchmode -executeMethod BuildTool.Build'
      }
    }
  }
}