#include <cassert>
#include <cstddef>
#include <cstdint>
#include <string>
#include <array>
#include <algorithm>

#include <iostream>

using namespace std;

const std::array<char, 4> Symbols = { 'A', 'T', 'G', 'C' };

struct Nucleotide {
    char symbol;
    size_t position;
    int chromosome_num;
    int gene_num;
    bool is_marked;
    char service_info;
};

struct CompactNucleotide {                                   //не должен превышать 8 байтов
    uint32_t position : 32;     //от 0 до 3,3 млрд
    uint16_t gene_num : 15;     //от 1 до 25 тыс.
    uint8_t is_marked : 1;      //был ранее или нет
    uint8_t service_info : 8;   //может быть любым символом
    uint8_t chromosome_num : 6; //от 1 до 46
    uint8_t symbol : 2;         //A, T, G или С
};

CompactNucleotide Compress(const Nucleotide& n) {
    uint8_t new_symbol = distance(Symbols.begin(), find(Symbols.begin(), Symbols.end(), n.symbol));
    return CompactNucleotide{ static_cast<uint32_t>(n.position),
                              static_cast<uint16_t>(n.gene_num),
                              static_cast<uint8_t>(n.is_marked),
                              static_cast<uint8_t>(n.service_info),
                              static_cast<uint8_t>(n.chromosome_num),
                              (new_symbol) };
}

Nucleotide Decompress(const CompactNucleotide& cn) {
    char new_symbol = Symbols[cn.symbol];
    return Nucleotide{ new_symbol,
                       cn.position,
                       cn.chromosome_num,
                       cn.gene_num,
                       static_cast<bool>(cn.is_marked),
                       static_cast<char>(cn.service_info) };
}

static_assert(sizeof(CompactNucleotide) <= 8, "Your CompactNucleotide is not compact enough"s);
static_assert(alignof(CompactNucleotide) == 4, "Don't use '#pragma pack'!"s);
bool operator==(const Nucleotide& lhs, const Nucleotide& rhs) {
    return (lhs.symbol == rhs.symbol) && (lhs.position == rhs.position) && (lhs.chromosome_num == rhs.chromosome_num)
        && (lhs.gene_num == rhs.gene_num) && (lhs.is_marked == rhs.is_marked) && (lhs.service_info == rhs.service_info);
}
void TestSize() {
    assert(sizeof(CompactNucleotide) <= 8);
}
void TestCompressDecompress() {
    Nucleotide source;
    source.symbol = 'T';
    source.position = 1'000'000'000;
    source.chromosome_num = 48;
    source.gene_num = 1'000;
    source.is_marked = true;
    source.service_info = '!';

    CompactNucleotide compressedSource = Compress(source);
    Nucleotide decompressedSource = Decompress(compressedSource);

    assert(source == decompressedSource);
}

int main() {
    TestSize();
    TestCompressDecompress();
}