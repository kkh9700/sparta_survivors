
# B09-Sparta Survivors
 
<p>
</p>

## 🦆 구구덕 조 Team Notion
URL : [09 - 구구덕 (notion.site)](https://teamsparta.notion.site/09-6e10d82f2c4c43f5a5f23a398eb48b20)
 ## :one: 프로젝트 소개
끊임없이 몰려오는 적을 상대로 생존하는 서바이벌 게임입니다.
## :two: 개발기간
- 23.09.08(금) ~ 23.09.14(목)

### :raising_hand: 멤버구성
- 강성호 - 몬스터 소환, Stage가 올라갈 때 난이도 증가, 몬스터 종류 추가, 몬스터 애니메이션 추가
- 김경환 - 특수기능(대쉬, 불릿타임), 아이템 구현, 사운드(BGM, 효과음), 게임오버 UI
- 이민열 - 플레이어 공격, 몬스터 타겟팅, 시간 점수 표시, 일시정지, bullet 자동삭제
- 김하늘 - 타이틀 UI
- 우성훈 - 아이템 기능 구현(스피드 증가, EXP, HP회복), 아이템 드랍테이블 조원 도움받아서 진행


### :hammer: 개발 환경 
- Unity

## :clipboard: 구현 목록

### 1. 시작화면
게임 시작, 점수, 설정 버튼이 있습니다.
각 버튼을 누르면 각 기능의 화면으로 넘어갑니다.

![시작1](https://github.com/kkh9700/sparta_survivors/assets/70570791/ef0f2a5c-162b-4948-b3b5-5d400c358ea5)

### 1 - 1. 점수
플레이어의 점수를 확인할 수 있습니다.

![점수1](https://github.com/kkh9700/sparta_survivors/assets/70570791/8379948c-fa20-4283-b792-febc96eb4849)

### 1 - 2. 설정
게임과 관련된 설정을 할 수 있습니다. 

-  화면 설정은 해상도 설정과 전체화면 On/Off 할 수 있습니다.
- 소리 설정은 게임의 음량을 조절할 수 있습니다.
- 일반 설정은 게임의 조작법을 알 수 있고 게임의 데이터 초기화가 가능합니다.
![설정](https://github.com/kkh9700/sparta_survivors/assets/70570791/32adf10a-c2c3-464f-8b24-fdb51ac788ae)

### 1 - 3. 게임 시작
메인 게임을 진행할 수 있습니다. 

![게임화면1](https://github.com/kkh9700/sparta_survivors/assets/70570791/075d27d8-2372-4b2b-8bbf-c99cc36e0ba4)

### 2. 게임
게임의 기본적인 진행은 몬스터를 잡고 경험치와 아이템을 얻어 살아남아야 합니다.

#### 플레이어
- 자동공격 
- 대쉬 <Space Bar 버튼>
- Bullet Time (시간이 느려지는 기능) <Shift 버튼>

#### 몬스터
경험치와 아이템을 드랍합니다. 
스테이지가 반복되며 몬스터의 스텟은 점점 강해집니다.
- 1스테이지: 슬라임
- 2스테이지: 해골기사
- 3스테이지: 궁수
- 4스테이지: 보스 (한 마리 소환)


#### 아이템
- 체력 포션
- 이동속도 증가 포션
#### 스테이지 
한 스테이지가 10초로 구성되있으며 10초가 지날 때 마다 몬스터가 강력해집니다.

![게임 영상](https://github.com/kkh9700/sparta_survivors/assets/70570791/c0f46acd-6b24-4484-9085-4c8392909212)

## 🟥 구현하지 못한 부분
- 점수 저장
- 레벨업 보상


## :sob: 어려웠던 점

- 강성호 - 몬스터의 스텟 벨런스 조정, 애니메이션의 다양성 구현 (몬스터 죽었을 때, 플레이어에게 닿았을 때), 몬스터의 스킬 구현, 팀원이 제작한 코드를 완벽히 이해하고 알맞게 수정하기, 적절한 에셋 구하기
- 김하늘 - Dropdown, ScrollView UI 적용시키기 괜찮은 무료 에셋 구하기
- 우성훈 - 깃허브 사용법 미숙으로 팀프로젝트 진행에 어려움 겪음, 아이템 기능 구현에서 스텟 수치 추가하는 부분이 이해가 안간점, 아이템 드랍테이블 설정 등 전체적으로 지식이 부족해서 진행에 힘들었던 부분
- 김경환 - BulletTime 기능을 만들때 TimeScale을 조작해서 만들었는데 일시정지 기능과 겹치는 부분이 있어서 그 부분이 어려웠습니다.
- 이민열 - 오브젝트 풀링 rigidbody 함수 종류 깃허브 브랜치 머지 어울리는 이미지 구하기

## 느낀 점
- 강성호 - 
- 김하늘 - 
- 우성훈 - C# 부분이 부족하여 스크립트 작성이 많이 힘들게 느껴졌습니다.
- 김경환 - C#과 Unity를 사용하는데 아직 부족함이 많다는 걸 느꼈습니다.
- 이민열 - 


