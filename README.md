# Unity-AudioManager
유니티 오디오 매니저

<br>

* Resources/Audio 안에 있는 AudioData 와 같은 형식으로 key, clip, volume 을 세팅 후
AudioManager.Play() 를 통해 실행.

* AudioManagedSource를 통해 재생중이지 않은 소스는 자동 pool 로 Realase 됨.
