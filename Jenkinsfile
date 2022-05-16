pipeline {
    agent any 
    stages {
        stage("Building the API") {
            when {
                anyOf {
                    changeset "TitanMarketBackend/TitanMarket.WebApi/**"
                    changeset "TitanMarketBackend/TitanMarket.Domain/**"
                    changeset "TitanMarketBackend/TitanMarket.DB/**"
                    changeset "TitanMarketBackend/TitanMarket.Core/**"
                    changeset "TitanMarketBackend/Security/**"
                }
            } 
            steps {
                sh "dotnet build TitanMarketBackend/TitanMarket.sln"
                sh "docker-compose --env-file config/Test.env build api"
            }
        }
        stage ("Test") {
            steps {
                dir("TitanMarketBackend/TitanMarket.Core.Test") { 
                    sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"
                }

                dir("TitanMarketBackend/TitanMarket.Domain.Test") { 
                    sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"
                }
            }
            post {
                success {
                    publishCoverage adapters: [coberturaAdapter("TitanMarketBackend/TitanMarket.Core.Test/TestResults/*/coverage.cobertura.xml")]
                    publishCoverage adapters: [coberturaAdapter("TitanMarketBackend/TitanMarket.Domain.Test/TestResults/*/coverage.cobertura.xml")]
                }
            }
        }
        stage("Clean containers") {
            steps {
                script {
                    try {
                        sh "docker-compose --env-file config/Test.env down"
                    }
                    finally { }
                }
            }
        }
        stage("Deploy API") {
            steps {
                sh "docker-compose --env-file config/Test.env up -d"
            }
        }
        stage("Push images to registry") {
            steps {
                sh "docker-compose --env-file config/Test.env push"
            }
        }
     }
     post {
        always {
            sh "echo 'The pipeline has finished!'"
            discordSend description: "Jenkins Pipeline Build", footer: "Footer Text", link: env.BUILD_URL, result: currentBuild.currentResult, title: JOB_NAME, webhookURL: 'https://discord.com/api/webhooks/953976986844414022/aYoQH5cyXWw4ehrEoR2V-22fBxXbZyy37iUzgocXivy6Bgreq8av3vc_vflEe8ztE9b0'
        }
    }
}