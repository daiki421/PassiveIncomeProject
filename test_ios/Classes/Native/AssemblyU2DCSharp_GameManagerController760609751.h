#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// BlockStatusController
struct BlockStatusController_t2608554987;
// BlockController
struct BlockController_t454875615;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// PlayerController
struct PlayerController_t4148409433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManagerController
struct  GameManagerController_t760609751  : public MonoBehaviour_t1158329972
{
public:
	// BlockStatusController GameManagerController::bsScript
	BlockStatusController_t2608554987 * ___bsScript_2;
	// BlockController GameManagerController::bcScript
	BlockController_t454875615 * ___bcScript_3;
	// System.Int32[] GameManagerController::countDel
	Int32U5BU5D_t3030399641* ___countDel_4;
	// UnityEngine.GameObject GameManagerController::rayCut
	GameObject_t1756533147 * ___rayCut_5;
	// PlayerController GameManagerController::pScript
	PlayerController_t4148409433 * ___pScript_6;

public:
	inline static int32_t get_offset_of_bsScript_2() { return static_cast<int32_t>(offsetof(GameManagerController_t760609751, ___bsScript_2)); }
	inline BlockStatusController_t2608554987 * get_bsScript_2() const { return ___bsScript_2; }
	inline BlockStatusController_t2608554987 ** get_address_of_bsScript_2() { return &___bsScript_2; }
	inline void set_bsScript_2(BlockStatusController_t2608554987 * value)
	{
		___bsScript_2 = value;
		Il2CppCodeGenWriteBarrier(&___bsScript_2, value);
	}

	inline static int32_t get_offset_of_bcScript_3() { return static_cast<int32_t>(offsetof(GameManagerController_t760609751, ___bcScript_3)); }
	inline BlockController_t454875615 * get_bcScript_3() const { return ___bcScript_3; }
	inline BlockController_t454875615 ** get_address_of_bcScript_3() { return &___bcScript_3; }
	inline void set_bcScript_3(BlockController_t454875615 * value)
	{
		___bcScript_3 = value;
		Il2CppCodeGenWriteBarrier(&___bcScript_3, value);
	}

	inline static int32_t get_offset_of_countDel_4() { return static_cast<int32_t>(offsetof(GameManagerController_t760609751, ___countDel_4)); }
	inline Int32U5BU5D_t3030399641* get_countDel_4() const { return ___countDel_4; }
	inline Int32U5BU5D_t3030399641** get_address_of_countDel_4() { return &___countDel_4; }
	inline void set_countDel_4(Int32U5BU5D_t3030399641* value)
	{
		___countDel_4 = value;
		Il2CppCodeGenWriteBarrier(&___countDel_4, value);
	}

	inline static int32_t get_offset_of_rayCut_5() { return static_cast<int32_t>(offsetof(GameManagerController_t760609751, ___rayCut_5)); }
	inline GameObject_t1756533147 * get_rayCut_5() const { return ___rayCut_5; }
	inline GameObject_t1756533147 ** get_address_of_rayCut_5() { return &___rayCut_5; }
	inline void set_rayCut_5(GameObject_t1756533147 * value)
	{
		___rayCut_5 = value;
		Il2CppCodeGenWriteBarrier(&___rayCut_5, value);
	}

	inline static int32_t get_offset_of_pScript_6() { return static_cast<int32_t>(offsetof(GameManagerController_t760609751, ___pScript_6)); }
	inline PlayerController_t4148409433 * get_pScript_6() const { return ___pScript_6; }
	inline PlayerController_t4148409433 ** get_address_of_pScript_6() { return &___pScript_6; }
	inline void set_pScript_6(PlayerController_t4148409433 * value)
	{
		___pScript_6 = value;
		Il2CppCodeGenWriteBarrier(&___pScript_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
