// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ColumnInfo.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from ColumnInfo.proto</summary>
public static partial class ColumnInfoReflection {

  #region Descriptor
  /// <summary>File descriptor for ColumnInfo.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static ColumnInfoReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChBDb2x1bW5JbmZvLnByb3RvGhFXaW5kb3dSYW5nZS5wcm90byKCAQoPQ29s",
          "dW1uSW5mb1Byb3RvEiQKCWluZGV4TGlzdBgBIAMoCzIRLkNvbHVtbkluZGV4",
          "UHJvdG8SDAoEdHlwZRgCIAEoCRIQCghhaXJkUGF0aBgDIAEoCRITCgttelBy",
          "ZWNpc2lvbhgEIAEoBRIUCgxpbnRQcmVjaXNpb24YBSABKAUijQMKEENvbHVt",
          "bkluZGV4UHJvdG8SDQoFbGV2ZWwYASABKAUSEAoIc3RhcnRQdHIYAiABKAMS",
          "DgoGZW5kUHRyGAMgASgDEiAKBXJhbmdlGAQgASgLMhEuV2luZG93UmFuZ2VQ",
          "cm90bxIWCg5zdGFydE16TGlzdFB0chgFIAEoAxIUCgxlbmRNekxpc3RQdHIY",
          "BiABKAMSFgoOc3RhcnRSdExpc3RQdHIYByABKAMSFAoMZW5kUnRMaXN0UHRy",
          "GAggASgDEh0KFXN0YXJ0U3BlY3RyYUlkTGlzdFB0chgJIAEoAxIbChNlbmRT",
          "cGVjdHJhSWRMaXN0UHRyGAogASgDEh0KFXN0YXJ0SW50ZW5zaXR5TGlzdFB0",
          "chgLIAEoAxIbChNlbmRJbnRlbnNpdHlMaXN0UHRyGAwgASgDEgsKA216cxgN",
          "IAMoBRILCgNydHMYDiADKAUSEgoKc3BlY3RyYUlkcxgPIAMoBRITCgtpbnRl",
          "bnNpdGllcxgQIAMoBRIPCgdhbmNob3JzGBEgAygDYgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { global::WindowRangeReflection.Descriptor, },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::ColumnInfoProto), global::ColumnInfoProto.Parser, new[]{ "IndexList", "Type", "AirdPath", "MzPrecision", "IntPrecision" }, null, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::ColumnIndexProto), global::ColumnIndexProto.Parser, new[]{ "Level", "StartPtr", "EndPtr", "Range", "StartMzListPtr", "EndMzListPtr", "StartRtListPtr", "EndRtListPtr", "StartSpectraIdListPtr", "EndSpectraIdListPtr", "StartIntensityListPtr", "EndIntensityListPtr", "Mzs", "Rts", "SpectraIds", "Intensities", "Anchors" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
[global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
public sealed partial class ColumnInfoProto : pb::IMessage<ColumnInfoProto>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<ColumnInfoProto> _parser = new pb::MessageParser<ColumnInfoProto>(() => new ColumnInfoProto());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<ColumnInfoProto> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ColumnInfoReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ColumnInfoProto() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ColumnInfoProto(ColumnInfoProto other) : this() {
    indexList_ = other.indexList_.Clone();
    type_ = other.type_;
    airdPath_ = other.airdPath_;
    mzPrecision_ = other.mzPrecision_;
    intPrecision_ = other.intPrecision_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ColumnInfoProto Clone() {
    return new ColumnInfoProto(this);
  }

  /// <summary>Field number for the "indexList" field.</summary>
  public const int IndexListFieldNumber = 1;
  private static readonly pb::FieldCodec<global::ColumnIndexProto> _repeated_indexList_codec
      = pb::FieldCodec.ForMessage(10, global::ColumnIndexProto.Parser);
  private readonly pbc::RepeatedField<global::ColumnIndexProto> indexList_ = new pbc::RepeatedField<global::ColumnIndexProto>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<global::ColumnIndexProto> IndexList {
    get { return indexList_; }
  }

  /// <summary>Field number for the "type" field.</summary>
  public const int TypeFieldNumber = 2;
  private string type_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Type {
    get { return type_; }
    set {
      type_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "airdPath" field.</summary>
  public const int AirdPathFieldNumber = 3;
  private string airdPath_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string AirdPath {
    get { return airdPath_; }
    set {
      airdPath_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "mzPrecision" field.</summary>
  public const int MzPrecisionFieldNumber = 4;
  private int mzPrecision_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int MzPrecision {
    get { return mzPrecision_; }
    set {
      mzPrecision_ = value;
    }
  }

  /// <summary>Field number for the "intPrecision" field.</summary>
  public const int IntPrecisionFieldNumber = 5;
  private int intPrecision_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int IntPrecision {
    get { return intPrecision_; }
    set {
      intPrecision_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as ColumnInfoProto);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(ColumnInfoProto other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if(!indexList_.Equals(other.indexList_)) return false;
    if (Type != other.Type) return false;
    if (AirdPath != other.AirdPath) return false;
    if (MzPrecision != other.MzPrecision) return false;
    if (IntPrecision != other.IntPrecision) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    hash ^= indexList_.GetHashCode();
    if (Type.Length != 0) hash ^= Type.GetHashCode();
    if (AirdPath.Length != 0) hash ^= AirdPath.GetHashCode();
    if (MzPrecision != 0) hash ^= MzPrecision.GetHashCode();
    if (IntPrecision != 0) hash ^= IntPrecision.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    indexList_.WriteTo(output, _repeated_indexList_codec);
    if (Type.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Type);
    }
    if (AirdPath.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(AirdPath);
    }
    if (MzPrecision != 0) {
      output.WriteRawTag(32);
      output.WriteInt32(MzPrecision);
    }
    if (IntPrecision != 0) {
      output.WriteRawTag(40);
      output.WriteInt32(IntPrecision);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    indexList_.WriteTo(ref output, _repeated_indexList_codec);
    if (Type.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Type);
    }
    if (AirdPath.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(AirdPath);
    }
    if (MzPrecision != 0) {
      output.WriteRawTag(32);
      output.WriteInt32(MzPrecision);
    }
    if (IntPrecision != 0) {
      output.WriteRawTag(40);
      output.WriteInt32(IntPrecision);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    size += indexList_.CalculateSize(_repeated_indexList_codec);
    if (Type.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Type);
    }
    if (AirdPath.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(AirdPath);
    }
    if (MzPrecision != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(MzPrecision);
    }
    if (IntPrecision != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(IntPrecision);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(ColumnInfoProto other) {
    if (other == null) {
      return;
    }
    indexList_.Add(other.indexList_);
    if (other.Type.Length != 0) {
      Type = other.Type;
    }
    if (other.AirdPath.Length != 0) {
      AirdPath = other.AirdPath;
    }
    if (other.MzPrecision != 0) {
      MzPrecision = other.MzPrecision;
    }
    if (other.IntPrecision != 0) {
      IntPrecision = other.IntPrecision;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          indexList_.AddEntriesFrom(input, _repeated_indexList_codec);
          break;
        }
        case 18: {
          Type = input.ReadString();
          break;
        }
        case 26: {
          AirdPath = input.ReadString();
          break;
        }
        case 32: {
          MzPrecision = input.ReadInt32();
          break;
        }
        case 40: {
          IntPrecision = input.ReadInt32();
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          indexList_.AddEntriesFrom(ref input, _repeated_indexList_codec);
          break;
        }
        case 18: {
          Type = input.ReadString();
          break;
        }
        case 26: {
          AirdPath = input.ReadString();
          break;
        }
        case 32: {
          MzPrecision = input.ReadInt32();
          break;
        }
        case 40: {
          IntPrecision = input.ReadInt32();
          break;
        }
      }
    }
  }
  #endif

}

[global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
public sealed partial class ColumnIndexProto : pb::IMessage<ColumnIndexProto>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<ColumnIndexProto> _parser = new pb::MessageParser<ColumnIndexProto>(() => new ColumnIndexProto());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<ColumnIndexProto> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ColumnInfoReflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ColumnIndexProto() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ColumnIndexProto(ColumnIndexProto other) : this() {
    level_ = other.level_;
    startPtr_ = other.startPtr_;
    endPtr_ = other.endPtr_;
    range_ = other.range_ != null ? other.range_.Clone() : null;
    startMzListPtr_ = other.startMzListPtr_;
    endMzListPtr_ = other.endMzListPtr_;
    startRtListPtr_ = other.startRtListPtr_;
    endRtListPtr_ = other.endRtListPtr_;
    startSpectraIdListPtr_ = other.startSpectraIdListPtr_;
    endSpectraIdListPtr_ = other.endSpectraIdListPtr_;
    startIntensityListPtr_ = other.startIntensityListPtr_;
    endIntensityListPtr_ = other.endIntensityListPtr_;
    mzs_ = other.mzs_.Clone();
    rts_ = other.rts_.Clone();
    spectraIds_ = other.spectraIds_.Clone();
    intensities_ = other.intensities_.Clone();
    anchors_ = other.anchors_.Clone();
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ColumnIndexProto Clone() {
    return new ColumnIndexProto(this);
  }

  /// <summary>Field number for the "level" field.</summary>
  public const int LevelFieldNumber = 1;
  private int level_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int Level {
    get { return level_; }
    set {
      level_ = value;
    }
  }

  /// <summary>Field number for the "startPtr" field.</summary>
  public const int StartPtrFieldNumber = 2;
  private long startPtr_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long StartPtr {
    get { return startPtr_; }
    set {
      startPtr_ = value;
    }
  }

  /// <summary>Field number for the "endPtr" field.</summary>
  public const int EndPtrFieldNumber = 3;
  private long endPtr_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long EndPtr {
    get { return endPtr_; }
    set {
      endPtr_ = value;
    }
  }

  /// <summary>Field number for the "range" field.</summary>
  public const int RangeFieldNumber = 4;
  private global::WindowRangeProto range_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public global::WindowRangeProto Range {
    get { return range_; }
    set {
      range_ = value;
    }
  }

  /// <summary>Field number for the "startMzListPtr" field.</summary>
  public const int StartMzListPtrFieldNumber = 5;
  private long startMzListPtr_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long StartMzListPtr {
    get { return startMzListPtr_; }
    set {
      startMzListPtr_ = value;
    }
  }

  /// <summary>Field number for the "endMzListPtr" field.</summary>
  public const int EndMzListPtrFieldNumber = 6;
  private long endMzListPtr_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long EndMzListPtr {
    get { return endMzListPtr_; }
    set {
      endMzListPtr_ = value;
    }
  }

  /// <summary>Field number for the "startRtListPtr" field.</summary>
  public const int StartRtListPtrFieldNumber = 7;
  private long startRtListPtr_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long StartRtListPtr {
    get { return startRtListPtr_; }
    set {
      startRtListPtr_ = value;
    }
  }

  /// <summary>Field number for the "endRtListPtr" field.</summary>
  public const int EndRtListPtrFieldNumber = 8;
  private long endRtListPtr_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long EndRtListPtr {
    get { return endRtListPtr_; }
    set {
      endRtListPtr_ = value;
    }
  }

  /// <summary>Field number for the "startSpectraIdListPtr" field.</summary>
  public const int StartSpectraIdListPtrFieldNumber = 9;
  private long startSpectraIdListPtr_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long StartSpectraIdListPtr {
    get { return startSpectraIdListPtr_; }
    set {
      startSpectraIdListPtr_ = value;
    }
  }

  /// <summary>Field number for the "endSpectraIdListPtr" field.</summary>
  public const int EndSpectraIdListPtrFieldNumber = 10;
  private long endSpectraIdListPtr_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long EndSpectraIdListPtr {
    get { return endSpectraIdListPtr_; }
    set {
      endSpectraIdListPtr_ = value;
    }
  }

  /// <summary>Field number for the "startIntensityListPtr" field.</summary>
  public const int StartIntensityListPtrFieldNumber = 11;
  private long startIntensityListPtr_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long StartIntensityListPtr {
    get { return startIntensityListPtr_; }
    set {
      startIntensityListPtr_ = value;
    }
  }

  /// <summary>Field number for the "endIntensityListPtr" field.</summary>
  public const int EndIntensityListPtrFieldNumber = 12;
  private long endIntensityListPtr_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long EndIntensityListPtr {
    get { return endIntensityListPtr_; }
    set {
      endIntensityListPtr_ = value;
    }
  }

  /// <summary>Field number for the "mzs" field.</summary>
  public const int MzsFieldNumber = 13;
  private static readonly pb::FieldCodec<int> _repeated_mzs_codec
      = pb::FieldCodec.ForInt32(106);
  private readonly pbc::RepeatedField<int> mzs_ = new pbc::RepeatedField<int>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<int> Mzs {
    get { return mzs_; }
  }

  /// <summary>Field number for the "rts" field.</summary>
  public const int RtsFieldNumber = 14;
  private static readonly pb::FieldCodec<int> _repeated_rts_codec
      = pb::FieldCodec.ForInt32(114);
  private readonly pbc::RepeatedField<int> rts_ = new pbc::RepeatedField<int>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<int> Rts {
    get { return rts_; }
  }

  /// <summary>Field number for the "spectraIds" field.</summary>
  public const int SpectraIdsFieldNumber = 15;
  private static readonly pb::FieldCodec<int> _repeated_spectraIds_codec
      = pb::FieldCodec.ForInt32(122);
  private readonly pbc::RepeatedField<int> spectraIds_ = new pbc::RepeatedField<int>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<int> SpectraIds {
    get { return spectraIds_; }
  }

  /// <summary>Field number for the "intensities" field.</summary>
  public const int IntensitiesFieldNumber = 16;
  private static readonly pb::FieldCodec<int> _repeated_intensities_codec
      = pb::FieldCodec.ForInt32(130);
  private readonly pbc::RepeatedField<int> intensities_ = new pbc::RepeatedField<int>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<int> Intensities {
    get { return intensities_; }
  }

  /// <summary>Field number for the "anchors" field.</summary>
  public const int AnchorsFieldNumber = 17;
  private static readonly pb::FieldCodec<long> _repeated_anchors_codec
      = pb::FieldCodec.ForInt64(138);
  private readonly pbc::RepeatedField<long> anchors_ = new pbc::RepeatedField<long>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<long> Anchors {
    get { return anchors_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as ColumnIndexProto);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(ColumnIndexProto other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Level != other.Level) return false;
    if (StartPtr != other.StartPtr) return false;
    if (EndPtr != other.EndPtr) return false;
    if (!object.Equals(Range, other.Range)) return false;
    if (StartMzListPtr != other.StartMzListPtr) return false;
    if (EndMzListPtr != other.EndMzListPtr) return false;
    if (StartRtListPtr != other.StartRtListPtr) return false;
    if (EndRtListPtr != other.EndRtListPtr) return false;
    if (StartSpectraIdListPtr != other.StartSpectraIdListPtr) return false;
    if (EndSpectraIdListPtr != other.EndSpectraIdListPtr) return false;
    if (StartIntensityListPtr != other.StartIntensityListPtr) return false;
    if (EndIntensityListPtr != other.EndIntensityListPtr) return false;
    if(!mzs_.Equals(other.mzs_)) return false;
    if(!rts_.Equals(other.rts_)) return false;
    if(!spectraIds_.Equals(other.spectraIds_)) return false;
    if(!intensities_.Equals(other.intensities_)) return false;
    if(!anchors_.Equals(other.anchors_)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (Level != 0) hash ^= Level.GetHashCode();
    if (StartPtr != 0L) hash ^= StartPtr.GetHashCode();
    if (EndPtr != 0L) hash ^= EndPtr.GetHashCode();
    if (range_ != null) hash ^= Range.GetHashCode();
    if (StartMzListPtr != 0L) hash ^= StartMzListPtr.GetHashCode();
    if (EndMzListPtr != 0L) hash ^= EndMzListPtr.GetHashCode();
    if (StartRtListPtr != 0L) hash ^= StartRtListPtr.GetHashCode();
    if (EndRtListPtr != 0L) hash ^= EndRtListPtr.GetHashCode();
    if (StartSpectraIdListPtr != 0L) hash ^= StartSpectraIdListPtr.GetHashCode();
    if (EndSpectraIdListPtr != 0L) hash ^= EndSpectraIdListPtr.GetHashCode();
    if (StartIntensityListPtr != 0L) hash ^= StartIntensityListPtr.GetHashCode();
    if (EndIntensityListPtr != 0L) hash ^= EndIntensityListPtr.GetHashCode();
    hash ^= mzs_.GetHashCode();
    hash ^= rts_.GetHashCode();
    hash ^= spectraIds_.GetHashCode();
    hash ^= intensities_.GetHashCode();
    hash ^= anchors_.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Level != 0) {
      output.WriteRawTag(8);
      output.WriteInt32(Level);
    }
    if (StartPtr != 0L) {
      output.WriteRawTag(16);
      output.WriteInt64(StartPtr);
    }
    if (EndPtr != 0L) {
      output.WriteRawTag(24);
      output.WriteInt64(EndPtr);
    }
    if (range_ != null) {
      output.WriteRawTag(34);
      output.WriteMessage(Range);
    }
    if (StartMzListPtr != 0L) {
      output.WriteRawTag(40);
      output.WriteInt64(StartMzListPtr);
    }
    if (EndMzListPtr != 0L) {
      output.WriteRawTag(48);
      output.WriteInt64(EndMzListPtr);
    }
    if (StartRtListPtr != 0L) {
      output.WriteRawTag(56);
      output.WriteInt64(StartRtListPtr);
    }
    if (EndRtListPtr != 0L) {
      output.WriteRawTag(64);
      output.WriteInt64(EndRtListPtr);
    }
    if (StartSpectraIdListPtr != 0L) {
      output.WriteRawTag(72);
      output.WriteInt64(StartSpectraIdListPtr);
    }
    if (EndSpectraIdListPtr != 0L) {
      output.WriteRawTag(80);
      output.WriteInt64(EndSpectraIdListPtr);
    }
    if (StartIntensityListPtr != 0L) {
      output.WriteRawTag(88);
      output.WriteInt64(StartIntensityListPtr);
    }
    if (EndIntensityListPtr != 0L) {
      output.WriteRawTag(96);
      output.WriteInt64(EndIntensityListPtr);
    }
    mzs_.WriteTo(output, _repeated_mzs_codec);
    rts_.WriteTo(output, _repeated_rts_codec);
    spectraIds_.WriteTo(output, _repeated_spectraIds_codec);
    intensities_.WriteTo(output, _repeated_intensities_codec);
    anchors_.WriteTo(output, _repeated_anchors_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Level != 0) {
      output.WriteRawTag(8);
      output.WriteInt32(Level);
    }
    if (StartPtr != 0L) {
      output.WriteRawTag(16);
      output.WriteInt64(StartPtr);
    }
    if (EndPtr != 0L) {
      output.WriteRawTag(24);
      output.WriteInt64(EndPtr);
    }
    if (range_ != null) {
      output.WriteRawTag(34);
      output.WriteMessage(Range);
    }
    if (StartMzListPtr != 0L) {
      output.WriteRawTag(40);
      output.WriteInt64(StartMzListPtr);
    }
    if (EndMzListPtr != 0L) {
      output.WriteRawTag(48);
      output.WriteInt64(EndMzListPtr);
    }
    if (StartRtListPtr != 0L) {
      output.WriteRawTag(56);
      output.WriteInt64(StartRtListPtr);
    }
    if (EndRtListPtr != 0L) {
      output.WriteRawTag(64);
      output.WriteInt64(EndRtListPtr);
    }
    if (StartSpectraIdListPtr != 0L) {
      output.WriteRawTag(72);
      output.WriteInt64(StartSpectraIdListPtr);
    }
    if (EndSpectraIdListPtr != 0L) {
      output.WriteRawTag(80);
      output.WriteInt64(EndSpectraIdListPtr);
    }
    if (StartIntensityListPtr != 0L) {
      output.WriteRawTag(88);
      output.WriteInt64(StartIntensityListPtr);
    }
    if (EndIntensityListPtr != 0L) {
      output.WriteRawTag(96);
      output.WriteInt64(EndIntensityListPtr);
    }
    mzs_.WriteTo(ref output, _repeated_mzs_codec);
    rts_.WriteTo(ref output, _repeated_rts_codec);
    spectraIds_.WriteTo(ref output, _repeated_spectraIds_codec);
    intensities_.WriteTo(ref output, _repeated_intensities_codec);
    anchors_.WriteTo(ref output, _repeated_anchors_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (Level != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Level);
    }
    if (StartPtr != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(StartPtr);
    }
    if (EndPtr != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(EndPtr);
    }
    if (range_ != null) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(Range);
    }
    if (StartMzListPtr != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(StartMzListPtr);
    }
    if (EndMzListPtr != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(EndMzListPtr);
    }
    if (StartRtListPtr != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(StartRtListPtr);
    }
    if (EndRtListPtr != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(EndRtListPtr);
    }
    if (StartSpectraIdListPtr != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(StartSpectraIdListPtr);
    }
    if (EndSpectraIdListPtr != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(EndSpectraIdListPtr);
    }
    if (StartIntensityListPtr != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(StartIntensityListPtr);
    }
    if (EndIntensityListPtr != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(EndIntensityListPtr);
    }
    size += mzs_.CalculateSize(_repeated_mzs_codec);
    size += rts_.CalculateSize(_repeated_rts_codec);
    size += spectraIds_.CalculateSize(_repeated_spectraIds_codec);
    size += intensities_.CalculateSize(_repeated_intensities_codec);
    size += anchors_.CalculateSize(_repeated_anchors_codec);
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(ColumnIndexProto other) {
    if (other == null) {
      return;
    }
    if (other.Level != 0) {
      Level = other.Level;
    }
    if (other.StartPtr != 0L) {
      StartPtr = other.StartPtr;
    }
    if (other.EndPtr != 0L) {
      EndPtr = other.EndPtr;
    }
    if (other.range_ != null) {
      if (range_ == null) {
        Range = new global::WindowRangeProto();
      }
      Range.MergeFrom(other.Range);
    }
    if (other.StartMzListPtr != 0L) {
      StartMzListPtr = other.StartMzListPtr;
    }
    if (other.EndMzListPtr != 0L) {
      EndMzListPtr = other.EndMzListPtr;
    }
    if (other.StartRtListPtr != 0L) {
      StartRtListPtr = other.StartRtListPtr;
    }
    if (other.EndRtListPtr != 0L) {
      EndRtListPtr = other.EndRtListPtr;
    }
    if (other.StartSpectraIdListPtr != 0L) {
      StartSpectraIdListPtr = other.StartSpectraIdListPtr;
    }
    if (other.EndSpectraIdListPtr != 0L) {
      EndSpectraIdListPtr = other.EndSpectraIdListPtr;
    }
    if (other.StartIntensityListPtr != 0L) {
      StartIntensityListPtr = other.StartIntensityListPtr;
    }
    if (other.EndIntensityListPtr != 0L) {
      EndIntensityListPtr = other.EndIntensityListPtr;
    }
    mzs_.Add(other.mzs_);
    rts_.Add(other.rts_);
    spectraIds_.Add(other.spectraIds_);
    intensities_.Add(other.intensities_);
    anchors_.Add(other.anchors_);
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 8: {
          Level = input.ReadInt32();
          break;
        }
        case 16: {
          StartPtr = input.ReadInt64();
          break;
        }
        case 24: {
          EndPtr = input.ReadInt64();
          break;
        }
        case 34: {
          if (range_ == null) {
            Range = new global::WindowRangeProto();
          }
          input.ReadMessage(Range);
          break;
        }
        case 40: {
          StartMzListPtr = input.ReadInt64();
          break;
        }
        case 48: {
          EndMzListPtr = input.ReadInt64();
          break;
        }
        case 56: {
          StartRtListPtr = input.ReadInt64();
          break;
        }
        case 64: {
          EndRtListPtr = input.ReadInt64();
          break;
        }
        case 72: {
          StartSpectraIdListPtr = input.ReadInt64();
          break;
        }
        case 80: {
          EndSpectraIdListPtr = input.ReadInt64();
          break;
        }
        case 88: {
          StartIntensityListPtr = input.ReadInt64();
          break;
        }
        case 96: {
          EndIntensityListPtr = input.ReadInt64();
          break;
        }
        case 106:
        case 104: {
          mzs_.AddEntriesFrom(input, _repeated_mzs_codec);
          break;
        }
        case 114:
        case 112: {
          rts_.AddEntriesFrom(input, _repeated_rts_codec);
          break;
        }
        case 122:
        case 120: {
          spectraIds_.AddEntriesFrom(input, _repeated_spectraIds_codec);
          break;
        }
        case 130:
        case 128: {
          intensities_.AddEntriesFrom(input, _repeated_intensities_codec);
          break;
        }
        case 138:
        case 136: {
          anchors_.AddEntriesFrom(input, _repeated_anchors_codec);
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 8: {
          Level = input.ReadInt32();
          break;
        }
        case 16: {
          StartPtr = input.ReadInt64();
          break;
        }
        case 24: {
          EndPtr = input.ReadInt64();
          break;
        }
        case 34: {
          if (range_ == null) {
            Range = new global::WindowRangeProto();
          }
          input.ReadMessage(Range);
          break;
        }
        case 40: {
          StartMzListPtr = input.ReadInt64();
          break;
        }
        case 48: {
          EndMzListPtr = input.ReadInt64();
          break;
        }
        case 56: {
          StartRtListPtr = input.ReadInt64();
          break;
        }
        case 64: {
          EndRtListPtr = input.ReadInt64();
          break;
        }
        case 72: {
          StartSpectraIdListPtr = input.ReadInt64();
          break;
        }
        case 80: {
          EndSpectraIdListPtr = input.ReadInt64();
          break;
        }
        case 88: {
          StartIntensityListPtr = input.ReadInt64();
          break;
        }
        case 96: {
          EndIntensityListPtr = input.ReadInt64();
          break;
        }
        case 106:
        case 104: {
          mzs_.AddEntriesFrom(ref input, _repeated_mzs_codec);
          break;
        }
        case 114:
        case 112: {
          rts_.AddEntriesFrom(ref input, _repeated_rts_codec);
          break;
        }
        case 122:
        case 120: {
          spectraIds_.AddEntriesFrom(ref input, _repeated_spectraIds_codec);
          break;
        }
        case 130:
        case 128: {
          intensities_.AddEntriesFrom(ref input, _repeated_intensities_codec);
          break;
        }
        case 138:
        case 136: {
          anchors_.AddEntriesFrom(ref input, _repeated_anchors_codec);
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code
