#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "AssemblyU2DCSharp_iTween_EaseType818674011.h"
#include "AssemblyU2DCSharp_iTween_LoopType1490651981.h"
#include "UnityEngine_UnityEngine_Space4278750806.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"
#include "AssemblyU2DCSharp_iTween_NamedValueColor2874784184.h"

// System.Collections.Generic.List`1<System.Collections.Hashtable>
struct List_1_t278961118;
// System.String
struct String_t;
// System.Collections.Hashtable
struct Hashtable_t909839986;
// iTween/EasingFunction
struct EasingFunction_t3676968174;
// iTween/ApplyTween
struct ApplyTween_t747394300;
// UnityEngine.AudioSource
struct AudioSource_t1135106623;
// UnityEngine.Vector3[]
struct Vector3U5BU5D_t1172311765;
// UnityEngine.Vector2[]
struct Vector2U5BU5D_t686124026;
// UnityEngine.Color[0...,0...]
struct ColorU5BU2CU5D_t672350443;
// System.Single[]
struct SingleU5BU5D_t577127397;
// UnityEngine.Rect[]
struct RectU5BU5D_t1299715887;
// iTween/CRSpline
struct CRSpline_t4177960625;
// UnityEngine.Transform
struct Transform_t3275118058;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// iTween
struct  iTween_t488923914  : public MonoBehaviour_t1158329972
{
public:
	// System.String iTween::id
	String_t* ___id_3;
	// System.String iTween::type
	String_t* ___type_4;
	// System.String iTween::method
	String_t* ___method_5;
	// iTween/EaseType iTween::easeType
	int32_t ___easeType_6;
	// System.Single iTween::time
	float ___time_7;
	// System.Single iTween::delay
	float ___delay_8;
	// iTween/LoopType iTween::loopType
	int32_t ___loopType_9;
	// System.Boolean iTween::isRunning
	bool ___isRunning_10;
	// System.Boolean iTween::isPaused
	bool ___isPaused_11;
	// System.String iTween::_name
	String_t* ____name_12;
	// System.Single iTween::runningTime
	float ___runningTime_13;
	// System.Single iTween::percentage
	float ___percentage_14;
	// System.Single iTween::delayStarted
	float ___delayStarted_15;
	// System.Boolean iTween::kinematic
	bool ___kinematic_16;
	// System.Boolean iTween::isLocal
	bool ___isLocal_17;
	// System.Boolean iTween::loop
	bool ___loop_18;
	// System.Boolean iTween::reverse
	bool ___reverse_19;
	// System.Boolean iTween::wasPaused
	bool ___wasPaused_20;
	// System.Boolean iTween::physics
	bool ___physics_21;
	// System.Collections.Hashtable iTween::tweenArguments
	Hashtable_t909839986 * ___tweenArguments_22;
	// UnityEngine.Space iTween::space
	int32_t ___space_23;
	// iTween/EasingFunction iTween::ease
	EasingFunction_t3676968174 * ___ease_24;
	// iTween/ApplyTween iTween::apply
	ApplyTween_t747394300 * ___apply_25;
	// UnityEngine.AudioSource iTween::audioSource
	AudioSource_t1135106623 * ___audioSource_26;
	// UnityEngine.Vector3[] iTween::vector3s
	Vector3U5BU5D_t1172311765* ___vector3s_27;
	// UnityEngine.Vector2[] iTween::vector2s
	Vector2U5BU5D_t686124026* ___vector2s_28;
	// UnityEngine.Color[0...,0...] iTween::colors
	ColorU5BU2CU5D_t672350443* ___colors_29;
	// System.Single[] iTween::floats
	SingleU5BU5D_t577127397* ___floats_30;
	// UnityEngine.Rect[] iTween::rects
	RectU5BU5D_t1299715887* ___rects_31;
	// iTween/CRSpline iTween::path
	CRSpline_t4177960625 * ___path_32;
	// UnityEngine.Vector3 iTween::preUpdate
	Vector3_t2243707580  ___preUpdate_33;
	// UnityEngine.Vector3 iTween::postUpdate
	Vector3_t2243707580  ___postUpdate_34;
	// iTween/NamedValueColor iTween::namedcolorvalue
	int32_t ___namedcolorvalue_35;
	// System.Single iTween::lastRealTime
	float ___lastRealTime_36;
	// System.Boolean iTween::useRealTime
	bool ___useRealTime_37;
	// UnityEngine.Transform iTween::thisTransform
	Transform_t3275118058 * ___thisTransform_38;

public:
	inline static int32_t get_offset_of_id_3() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___id_3)); }
	inline String_t* get_id_3() const { return ___id_3; }
	inline String_t** get_address_of_id_3() { return &___id_3; }
	inline void set_id_3(String_t* value)
	{
		___id_3 = value;
		Il2CppCodeGenWriteBarrier(&___id_3, value);
	}

	inline static int32_t get_offset_of_type_4() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___type_4)); }
	inline String_t* get_type_4() const { return ___type_4; }
	inline String_t** get_address_of_type_4() { return &___type_4; }
	inline void set_type_4(String_t* value)
	{
		___type_4 = value;
		Il2CppCodeGenWriteBarrier(&___type_4, value);
	}

	inline static int32_t get_offset_of_method_5() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___method_5)); }
	inline String_t* get_method_5() const { return ___method_5; }
	inline String_t** get_address_of_method_5() { return &___method_5; }
	inline void set_method_5(String_t* value)
	{
		___method_5 = value;
		Il2CppCodeGenWriteBarrier(&___method_5, value);
	}

	inline static int32_t get_offset_of_easeType_6() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___easeType_6)); }
	inline int32_t get_easeType_6() const { return ___easeType_6; }
	inline int32_t* get_address_of_easeType_6() { return &___easeType_6; }
	inline void set_easeType_6(int32_t value)
	{
		___easeType_6 = value;
	}

	inline static int32_t get_offset_of_time_7() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___time_7)); }
	inline float get_time_7() const { return ___time_7; }
	inline float* get_address_of_time_7() { return &___time_7; }
	inline void set_time_7(float value)
	{
		___time_7 = value;
	}

	inline static int32_t get_offset_of_delay_8() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___delay_8)); }
	inline float get_delay_8() const { return ___delay_8; }
	inline float* get_address_of_delay_8() { return &___delay_8; }
	inline void set_delay_8(float value)
	{
		___delay_8 = value;
	}

	inline static int32_t get_offset_of_loopType_9() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___loopType_9)); }
	inline int32_t get_loopType_9() const { return ___loopType_9; }
	inline int32_t* get_address_of_loopType_9() { return &___loopType_9; }
	inline void set_loopType_9(int32_t value)
	{
		___loopType_9 = value;
	}

	inline static int32_t get_offset_of_isRunning_10() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___isRunning_10)); }
	inline bool get_isRunning_10() const { return ___isRunning_10; }
	inline bool* get_address_of_isRunning_10() { return &___isRunning_10; }
	inline void set_isRunning_10(bool value)
	{
		___isRunning_10 = value;
	}

	inline static int32_t get_offset_of_isPaused_11() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___isPaused_11)); }
	inline bool get_isPaused_11() const { return ___isPaused_11; }
	inline bool* get_address_of_isPaused_11() { return &___isPaused_11; }
	inline void set_isPaused_11(bool value)
	{
		___isPaused_11 = value;
	}

	inline static int32_t get_offset_of__name_12() { return static_cast<int32_t>(offsetof(iTween_t488923914, ____name_12)); }
	inline String_t* get__name_12() const { return ____name_12; }
	inline String_t** get_address_of__name_12() { return &____name_12; }
	inline void set__name_12(String_t* value)
	{
		____name_12 = value;
		Il2CppCodeGenWriteBarrier(&____name_12, value);
	}

	inline static int32_t get_offset_of_runningTime_13() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___runningTime_13)); }
	inline float get_runningTime_13() const { return ___runningTime_13; }
	inline float* get_address_of_runningTime_13() { return &___runningTime_13; }
	inline void set_runningTime_13(float value)
	{
		___runningTime_13 = value;
	}

	inline static int32_t get_offset_of_percentage_14() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___percentage_14)); }
	inline float get_percentage_14() const { return ___percentage_14; }
	inline float* get_address_of_percentage_14() { return &___percentage_14; }
	inline void set_percentage_14(float value)
	{
		___percentage_14 = value;
	}

	inline static int32_t get_offset_of_delayStarted_15() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___delayStarted_15)); }
	inline float get_delayStarted_15() const { return ___delayStarted_15; }
	inline float* get_address_of_delayStarted_15() { return &___delayStarted_15; }
	inline void set_delayStarted_15(float value)
	{
		___delayStarted_15 = value;
	}

	inline static int32_t get_offset_of_kinematic_16() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___kinematic_16)); }
	inline bool get_kinematic_16() const { return ___kinematic_16; }
	inline bool* get_address_of_kinematic_16() { return &___kinematic_16; }
	inline void set_kinematic_16(bool value)
	{
		___kinematic_16 = value;
	}

	inline static int32_t get_offset_of_isLocal_17() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___isLocal_17)); }
	inline bool get_isLocal_17() const { return ___isLocal_17; }
	inline bool* get_address_of_isLocal_17() { return &___isLocal_17; }
	inline void set_isLocal_17(bool value)
	{
		___isLocal_17 = value;
	}

	inline static int32_t get_offset_of_loop_18() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___loop_18)); }
	inline bool get_loop_18() const { return ___loop_18; }
	inline bool* get_address_of_loop_18() { return &___loop_18; }
	inline void set_loop_18(bool value)
	{
		___loop_18 = value;
	}

	inline static int32_t get_offset_of_reverse_19() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___reverse_19)); }
	inline bool get_reverse_19() const { return ___reverse_19; }
	inline bool* get_address_of_reverse_19() { return &___reverse_19; }
	inline void set_reverse_19(bool value)
	{
		___reverse_19 = value;
	}

	inline static int32_t get_offset_of_wasPaused_20() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___wasPaused_20)); }
	inline bool get_wasPaused_20() const { return ___wasPaused_20; }
	inline bool* get_address_of_wasPaused_20() { return &___wasPaused_20; }
	inline void set_wasPaused_20(bool value)
	{
		___wasPaused_20 = value;
	}

	inline static int32_t get_offset_of_physics_21() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___physics_21)); }
	inline bool get_physics_21() const { return ___physics_21; }
	inline bool* get_address_of_physics_21() { return &___physics_21; }
	inline void set_physics_21(bool value)
	{
		___physics_21 = value;
	}

	inline static int32_t get_offset_of_tweenArguments_22() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___tweenArguments_22)); }
	inline Hashtable_t909839986 * get_tweenArguments_22() const { return ___tweenArguments_22; }
	inline Hashtable_t909839986 ** get_address_of_tweenArguments_22() { return &___tweenArguments_22; }
	inline void set_tweenArguments_22(Hashtable_t909839986 * value)
	{
		___tweenArguments_22 = value;
		Il2CppCodeGenWriteBarrier(&___tweenArguments_22, value);
	}

	inline static int32_t get_offset_of_space_23() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___space_23)); }
	inline int32_t get_space_23() const { return ___space_23; }
	inline int32_t* get_address_of_space_23() { return &___space_23; }
	inline void set_space_23(int32_t value)
	{
		___space_23 = value;
	}

	inline static int32_t get_offset_of_ease_24() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___ease_24)); }
	inline EasingFunction_t3676968174 * get_ease_24() const { return ___ease_24; }
	inline EasingFunction_t3676968174 ** get_address_of_ease_24() { return &___ease_24; }
	inline void set_ease_24(EasingFunction_t3676968174 * value)
	{
		___ease_24 = value;
		Il2CppCodeGenWriteBarrier(&___ease_24, value);
	}

	inline static int32_t get_offset_of_apply_25() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___apply_25)); }
	inline ApplyTween_t747394300 * get_apply_25() const { return ___apply_25; }
	inline ApplyTween_t747394300 ** get_address_of_apply_25() { return &___apply_25; }
	inline void set_apply_25(ApplyTween_t747394300 * value)
	{
		___apply_25 = value;
		Il2CppCodeGenWriteBarrier(&___apply_25, value);
	}

	inline static int32_t get_offset_of_audioSource_26() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___audioSource_26)); }
	inline AudioSource_t1135106623 * get_audioSource_26() const { return ___audioSource_26; }
	inline AudioSource_t1135106623 ** get_address_of_audioSource_26() { return &___audioSource_26; }
	inline void set_audioSource_26(AudioSource_t1135106623 * value)
	{
		___audioSource_26 = value;
		Il2CppCodeGenWriteBarrier(&___audioSource_26, value);
	}

	inline static int32_t get_offset_of_vector3s_27() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___vector3s_27)); }
	inline Vector3U5BU5D_t1172311765* get_vector3s_27() const { return ___vector3s_27; }
	inline Vector3U5BU5D_t1172311765** get_address_of_vector3s_27() { return &___vector3s_27; }
	inline void set_vector3s_27(Vector3U5BU5D_t1172311765* value)
	{
		___vector3s_27 = value;
		Il2CppCodeGenWriteBarrier(&___vector3s_27, value);
	}

	inline static int32_t get_offset_of_vector2s_28() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___vector2s_28)); }
	inline Vector2U5BU5D_t686124026* get_vector2s_28() const { return ___vector2s_28; }
	inline Vector2U5BU5D_t686124026** get_address_of_vector2s_28() { return &___vector2s_28; }
	inline void set_vector2s_28(Vector2U5BU5D_t686124026* value)
	{
		___vector2s_28 = value;
		Il2CppCodeGenWriteBarrier(&___vector2s_28, value);
	}

	inline static int32_t get_offset_of_colors_29() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___colors_29)); }
	inline ColorU5BU2CU5D_t672350443* get_colors_29() const { return ___colors_29; }
	inline ColorU5BU2CU5D_t672350443** get_address_of_colors_29() { return &___colors_29; }
	inline void set_colors_29(ColorU5BU2CU5D_t672350443* value)
	{
		___colors_29 = value;
		Il2CppCodeGenWriteBarrier(&___colors_29, value);
	}

	inline static int32_t get_offset_of_floats_30() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___floats_30)); }
	inline SingleU5BU5D_t577127397* get_floats_30() const { return ___floats_30; }
	inline SingleU5BU5D_t577127397** get_address_of_floats_30() { return &___floats_30; }
	inline void set_floats_30(SingleU5BU5D_t577127397* value)
	{
		___floats_30 = value;
		Il2CppCodeGenWriteBarrier(&___floats_30, value);
	}

	inline static int32_t get_offset_of_rects_31() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___rects_31)); }
	inline RectU5BU5D_t1299715887* get_rects_31() const { return ___rects_31; }
	inline RectU5BU5D_t1299715887** get_address_of_rects_31() { return &___rects_31; }
	inline void set_rects_31(RectU5BU5D_t1299715887* value)
	{
		___rects_31 = value;
		Il2CppCodeGenWriteBarrier(&___rects_31, value);
	}

	inline static int32_t get_offset_of_path_32() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___path_32)); }
	inline CRSpline_t4177960625 * get_path_32() const { return ___path_32; }
	inline CRSpline_t4177960625 ** get_address_of_path_32() { return &___path_32; }
	inline void set_path_32(CRSpline_t4177960625 * value)
	{
		___path_32 = value;
		Il2CppCodeGenWriteBarrier(&___path_32, value);
	}

	inline static int32_t get_offset_of_preUpdate_33() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___preUpdate_33)); }
	inline Vector3_t2243707580  get_preUpdate_33() const { return ___preUpdate_33; }
	inline Vector3_t2243707580 * get_address_of_preUpdate_33() { return &___preUpdate_33; }
	inline void set_preUpdate_33(Vector3_t2243707580  value)
	{
		___preUpdate_33 = value;
	}

	inline static int32_t get_offset_of_postUpdate_34() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___postUpdate_34)); }
	inline Vector3_t2243707580  get_postUpdate_34() const { return ___postUpdate_34; }
	inline Vector3_t2243707580 * get_address_of_postUpdate_34() { return &___postUpdate_34; }
	inline void set_postUpdate_34(Vector3_t2243707580  value)
	{
		___postUpdate_34 = value;
	}

	inline static int32_t get_offset_of_namedcolorvalue_35() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___namedcolorvalue_35)); }
	inline int32_t get_namedcolorvalue_35() const { return ___namedcolorvalue_35; }
	inline int32_t* get_address_of_namedcolorvalue_35() { return &___namedcolorvalue_35; }
	inline void set_namedcolorvalue_35(int32_t value)
	{
		___namedcolorvalue_35 = value;
	}

	inline static int32_t get_offset_of_lastRealTime_36() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___lastRealTime_36)); }
	inline float get_lastRealTime_36() const { return ___lastRealTime_36; }
	inline float* get_address_of_lastRealTime_36() { return &___lastRealTime_36; }
	inline void set_lastRealTime_36(float value)
	{
		___lastRealTime_36 = value;
	}

	inline static int32_t get_offset_of_useRealTime_37() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___useRealTime_37)); }
	inline bool get_useRealTime_37() const { return ___useRealTime_37; }
	inline bool* get_address_of_useRealTime_37() { return &___useRealTime_37; }
	inline void set_useRealTime_37(bool value)
	{
		___useRealTime_37 = value;
	}

	inline static int32_t get_offset_of_thisTransform_38() { return static_cast<int32_t>(offsetof(iTween_t488923914, ___thisTransform_38)); }
	inline Transform_t3275118058 * get_thisTransform_38() const { return ___thisTransform_38; }
	inline Transform_t3275118058 ** get_address_of_thisTransform_38() { return &___thisTransform_38; }
	inline void set_thisTransform_38(Transform_t3275118058 * value)
	{
		___thisTransform_38 = value;
		Il2CppCodeGenWriteBarrier(&___thisTransform_38, value);
	}
};

struct iTween_t488923914_StaticFields
{
public:
	// System.Collections.Generic.List`1<System.Collections.Hashtable> iTween::tweens
	List_1_t278961118 * ___tweens_2;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> iTween::<>f__switch$map0
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map0_39;

public:
	inline static int32_t get_offset_of_tweens_2() { return static_cast<int32_t>(offsetof(iTween_t488923914_StaticFields, ___tweens_2)); }
	inline List_1_t278961118 * get_tweens_2() const { return ___tweens_2; }
	inline List_1_t278961118 ** get_address_of_tweens_2() { return &___tweens_2; }
	inline void set_tweens_2(List_1_t278961118 * value)
	{
		___tweens_2 = value;
		Il2CppCodeGenWriteBarrier(&___tweens_2, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map0_39() { return static_cast<int32_t>(offsetof(iTween_t488923914_StaticFields, ___U3CU3Ef__switchU24map0_39)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map0_39() const { return ___U3CU3Ef__switchU24map0_39; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map0_39() { return &___U3CU3Ef__switchU24map0_39; }
	inline void set_U3CU3Ef__switchU24map0_39(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map0_39 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map0_39, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
