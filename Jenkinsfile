pipeline {
  agent any
  stages {
    stage('Build') {
      parallel {
        stage('Build') {
          steps {
            echo 'Build'
            sh '''C:\\program files\\Unity\\Editor\\Unity.exe -quit -batchmode -executeMethod BuildTool.Build
'''
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