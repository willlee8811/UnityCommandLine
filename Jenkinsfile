pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        echo 'Build'
        sh 'sh "echo hello sh"'
      }
    }
    stage('Unity') {
      steps {
        echo '"$UNITY_PATH" -projectPath "$PROJECT_PATH" -logFile "$LOG_PATH"  -quit -batchmode -executeMethod BuildTool.Build'
      }
    }
  }
}