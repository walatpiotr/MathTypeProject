using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTypeProject
{
    class DictionaryWrapper
    {
        public Dictionary<char, string> unicodeToLatex = new Dictionary<char, string>();

        public DictionaryWrapper()
        {
            unicodeToLatex.Add('±', @"\pm ");
            unicodeToLatex.Add('∓', @"\mp ");
            unicodeToLatex.Add('×', @"\times ");
            unicodeToLatex.Add('÷', @"\div ");
            unicodeToLatex.Add('∝', @"\propto ");
            unicodeToLatex.Add('∕', @"/");
            unicodeToLatex.Add('*', @"\ast ");
            unicodeToLatex.Add('∘', @"\circ ");
            unicodeToLatex.Add('∙', @"\bullet ");
            unicodeToLatex.Add('⋅', @"\cdot ");
            unicodeToLatex.Add('∪', @"\cup ");
            unicodeToLatex.Add('∩', @"\cap ");
            unicodeToLatex.Add('⊎', @"\uplus ");
            unicodeToLatex.Add('⊓', @"\sqcap ");
            unicodeToLatex.Add('⊔', @"\sqcup ");
            unicodeToLatex.Add('∧', @"\wedge ");
            unicodeToLatex.Add('∨', @"\vee ");
            unicodeToLatex.Add('≮', @"\nless ");    //amssymb package
            unicodeToLatex.Add('≰', @"\nleq "); //amssymb package
            unicodeToLatex.Add('≯', @"\ngtr "); //amssymb package
            unicodeToLatex.Add('≱', @"\ngeq "); //amssymb package
            unicodeToLatex.Add('∼', @"\sim ");
            unicodeToLatex.Add('≃', @"\simeq ");
            unicodeToLatex.Add('≢', @"\not\equiv ");
            unicodeToLatex.Add('≄', @"\not\simeq ");
            unicodeToLatex.Add('≉', @"\not\approx ");
            unicodeToLatex.Add('≇', @"\ncong ");    //amssymb package
            unicodeToLatex.Add('∈', @"\in ");
            unicodeToLatex.Add('∋', @"\ni ");
            unicodeToLatex.Add('∉', @"\notin ");
            unicodeToLatex.Add('⊂', @"\subset ");
            unicodeToLatex.Add('⊃', @"\supset ");
            unicodeToLatex.Add('⊆', @"\subseteq ");
            unicodeToLatex.Add('⊇', @"\supseteq ");
            unicodeToLatex.Add('≺', @"\prec ");
            unicodeToLatex.Add('≻', @"\succ ");
            unicodeToLatex.Add('≼', @"\preceq ");
            unicodeToLatex.Add('≽', @"\succeq ");
            unicodeToLatex.Add('⊏', @"\sqsubset");  //amssymb package
            unicodeToLatex.Add('⊐', @"\sqsupset "); //amssymb package
            unicodeToLatex.Add('⊑', @"\sqsubseteq ");
            unicodeToLatex.Add('⊒', @"\sqsupseteq ");
            unicodeToLatex.Add('∥', @"\parallel ");
            unicodeToLatex.Add('⊥', @"\perp ");
            unicodeToLatex.Add('⊢', @"\vdash ");
            unicodeToLatex.Add('⊣', @"\dashv ");
            unicodeToLatex.Add('⋈', @"\bowtie ");
            unicodeToLatex.Add('≍', @"\asymp ");
            unicodeToLatex.Add('∑', @"\sum ");
            unicodeToLatex.Add('∫', @"\int ");
            unicodeToLatex.Add('∬', @"\iint "); //amsmath package
            unicodeToLatex.Add('∭', @"\iiint ");    //amsmath package
            unicodeToLatex.Add('∮', @"\oint ");
            unicodeToLatex.Add('∯', @"\oiint ");    //esint package
            unicodeToLatex.Add('∰', @"\oiiint ");   //fdsymbol package
            unicodeToLatex.Add('∱', @"\intclockwise ");   //stix package
            unicodeToLatex.Add('∲', @"\ointclockwise ");    //esint package
            unicodeToLatex.Add('∳', @"\ointctrclockwise "); //esint package
            unicodeToLatex.Add('∏', @"\prod ");
            unicodeToLatex.Add('∐', @"\coprod ");
            unicodeToLatex.Add('⋂', @"\bigcap ");
            unicodeToLatex.Add('⋃', @"\bigcup ");
            unicodeToLatex.Add('⋀', @"\bigwedge ");
            unicodeToLatex.Add('⋁', @"\bigvee ");
            unicodeToLatex.Add('⨀', @"\bigodot ");
            unicodeToLatex.Add('⨂', @"\bigotimes ");
            unicodeToLatex.Add('⨁', @"\bigoplus ");
            unicodeToLatex.Add('⨄', @"\biguplus ");
            unicodeToLatex.Add('⨃', @"\bigcupdot ");    //fdsymbol package
            unicodeToLatex.Add('∔', @"\dotplus ");  //amssymb package
            unicodeToLatex.Add('∸', @"\dotminus "); //fdsymbol package
            unicodeToLatex.Add('∖', @"\setminus ");
            unicodeToLatex.Add('⋒', @"\Cap ");  //amssymb package
            unicodeToLatex.Add('⋓', @"\Cup ");  //amssymb package
            unicodeToLatex.Add('⊟', @"\boxminus "); //amssymb package
            unicodeToLatex.Add('⊠', @"\boxtimes "); //amssymb package
            unicodeToLatex.Add('⊡', @"\boxdot ");   //amssymb package
            unicodeToLatex.Add('⊞', @"\boxplus ");  //amssymb package
            unicodeToLatex.Add('⋇', @"\divideontimes ");    //amssymb package
            unicodeToLatex.Add('⋉', @"\ltimes ");   //amssymb package
            unicodeToLatex.Add('⋊', @"\rtimes ");   //amssymb package
            unicodeToLatex.Add('⋋', @"\leftthreetimes ");   //amssymb package
            unicodeToLatex.Add('⋌', @"\rightthreetimes");   //amssymb package
            unicodeToLatex.Add('⋏', @"\curlywedge ");   //amssymb package
            unicodeToLatex.Add('⋎', @"\curlyvee "); //amssymb package
            unicodeToLatex.Add('⊝', @"\circleddash ");  //amssymb package
            unicodeToLatex.Add('⊺', @"\intercal "); //amssymb package
            unicodeToLatex.Add('⊕', @"\oplus ");
            unicodeToLatex.Add('⊖', @"\ominus ");
            unicodeToLatex.Add('⊗', @"\otimes ");
            unicodeToLatex.Add('⊘', @"\oslash ");
            unicodeToLatex.Add('⊙', @"\odot ");
            unicodeToLatex.Add('⊛', @"\oast "); //fdsymbol package
            unicodeToLatex.Add('⊚', @"\circledcirc ");    //amssymb package
            unicodeToLatex.Add('†', @"\dag ");
            unicodeToLatex.Add('‡', @"\ddag ");
            unicodeToLatex.Add('⋆', @"\star ");
            unicodeToLatex.Add('⋄', @"\diamond ");
            unicodeToLatex.Add('≀', @"\wr ");
            unicodeToLatex.Add('△', @"\triangle ");
            unicodeToLatex.Add('⨅', @"\bigsqcap "); //fdsymbol package
            unicodeToLatex.Add('⨆', @"\bigsqcup ");
            unicodeToLatex.Add('∴', @"\therefore ");    //amssymb package
            unicodeToLatex.Add('∵', @"\because ");  //amssymb package
            unicodeToLatex.Add('⋘', @"\lll ");  //amssymb package
            unicodeToLatex.Add('⋙', @"\ggg ");  //amssymb package
            unicodeToLatex.Add('≦', @"\leqq "); //amssymb package
            unicodeToLatex.Add('≧', @"\geqq "); //amssymb package
            unicodeToLatex.Add('≲', @"\lesssim ");  //amssymb package
            unicodeToLatex.Add('≳', @"\gtrsim ");   //amssymb package
            unicodeToLatex.Add('⋖', @"\lessdot ");  //amssymb package
            unicodeToLatex.Add('⋗', @"\gtrdot ");   //amssymb package
            unicodeToLatex.Add('≶', @"\lessgtr ");  //amssymb package
            unicodeToLatex.Add('⋚', @"\lesseqgtr ");    //amssymb package
            unicodeToLatex.Add('≷', @"\gtrless ");  //amssymb package
            unicodeToLatex.Add('⋛', @"\gtreqless ");    //amssymb package
            unicodeToLatex.Add('≑', @"\doteqdot "); //amssymb package
            unicodeToLatex.Add('≒', @"\fallingdotseq ");    //amssymb package
            unicodeToLatex.Add('≓', @"\risingdotseq "); //amssymb package
            unicodeToLatex.Add('∽', @"\backsim ");  //amssymb package
            unicodeToLatex.Add('≊', @"\approxeq "); //amssymb package
            unicodeToLatex.Add('⋍', @"\backsimeq ");  //amssymb package  
            unicodeToLatex.Add('⋞', @"\curlyeqprec ");  //amssymb package
            unicodeToLatex.Add('⋟', @"\curlyeqsucc ");  //amssymb package
            unicodeToLatex.Add('≾', @"\precsim ");  //amssymb package
            unicodeToLatex.Add('≿', @"\succsim ");  //amssymb package
            unicodeToLatex.Add('⋜', @"\eqless ");   //stix package
            unicodeToLatex.Add('⋝', @"\eqgtr ");    //stix package
            unicodeToLatex.Add('⊲', @"\vartriangleleft ");  //amssymb package
            unicodeToLatex.Add('⊳', @"\vartriangleright "); //amssymb package
            unicodeToLatex.Add('⊴', @"\trianglelefteq ");   //amssymb package
            unicodeToLatex.Add('⊵', @"\trianglerighteq ");  //amssymb package
            unicodeToLatex.Add('⊨', @"\models ");
            unicodeToLatex.Add('⋐', @"\Subset ");   //amssymb package
            unicodeToLatex.Add('⋑', @"\Supset ");   //amssymb package
            unicodeToLatex.Add('⊩', @"\Vdash ");    //amssymb package
            unicodeToLatex.Add('⊪', @"\Vvdash ");   //amssymb package
            unicodeToLatex.Add('≖', @"\eqcirc ");   //amssymb package
            unicodeToLatex.Add('≗', @"\circeq ");   //amssymb package
            unicodeToLatex.Add('≜', @"\triangleq ");    //amssymb package
            unicodeToLatex.Add('≏', @"\bumpeq ");   //amssymb package
            unicodeToLatex.Add('≎', @"\Bumpeq ");   //amssymb package
            unicodeToLatex.Add('≬', @"\between ");  //amssymb package
            unicodeToLatex.Add('⋔', @"\pitchfork ");    //amssymb package
            unicodeToLatex.Add('≐', @"\doteq ");
            unicodeToLatex.Add('≪', @"\ll ");   //amssymb package
            unicodeToLatex.Add('≫', @"\gg ");   //amssymb package
            unicodeToLatex.Add('≤', @"\leq ");  //amssymb package
            unicodeToLatex.Add('≥', @"\geq ");  //amssymb package
            unicodeToLatex.Add('≅', @"\cong ");
            unicodeToLatex.Add('≈', @"\approx ");
            unicodeToLatex.Add('≡', @"\equiv ");
            unicodeToLatex.Add('∞', @"\infty ");
            unicodeToLatex.Add('≠', @"\neq ");

            unicodeToLatex.Add('∀', @"\forall ");
            unicodeToLatex.Add('∂', @"\partial ");
            unicodeToLatex.Add('ð', @"\eth ");  //amssymb package
            unicodeToLatex.Add('ℇ', @"\mathcal{E} ");   //amssymb package
            unicodeToLatex.Add('Ϝ', @"\digamma ");  //stix package
            unicodeToLatex.Add('Ⅎ', @"\Finv "); //stix package
            unicodeToLatex.Add('ℏ', @"\hbar");
            unicodeToLatex.Add('℩', @"\turnediota ");   //stix package
            unicodeToLatex.Add('ı', @"\imath ");
            unicodeToLatex.Add('I', @"\topbot ");   //stix package
            unicodeToLatex.Add('ϰ', @"\varkappa "); //amssymb package
            unicodeToLatex.Add('℘', @"\wp ");
            unicodeToLatex.Add('℧', @"\mho ");  //amssymb package
            unicodeToLatex.Add('Å', @"\AA ");
            unicodeToLatex.Add('℮', @"\textestimated ");    //textcomp package
            unicodeToLatex.Add('∃', @"\exists ");
            unicodeToLatex.Add('∄', @"\nexists ");  //amssymb package
            unicodeToLatex.Add('ℵ', @"\aleph ");
            unicodeToLatex.Add('ℶ', @"\beth "); //amssymb package
            unicodeToLatex.Add('ℷ', @"\gimel ");    //amssymb package
            unicodeToLatex.Add('ℸ', @"\daleth ");   //amssymb package

            unicodeToLatex.Add('√', @"\sqrt[]{}");
            unicodeToLatex.Add('∛', @"\cbrt{}");
            unicodeToLatex.Add('∜', @"\qdrt{}");
            unicodeToLatex.Add('/', @"\frac{}{}");
            unicodeToLatex.Add('⁄', @"\frac{}{}");
            unicodeToLatex.Add('□', "expect parenthesis");
            unicodeToLatex.Add('█', "expect par with at");
            unicodeToLatex.Add('■', "expect matrix");
            unicodeToLatex.Add('⁡', @" ");    //function control sign
            unicodeToLatex.Add('^', @"^{}");
            unicodeToLatex.Add('_', @"_{}");
            unicodeToLatex.Add('▒', "big operator separator");
            unicodeToLatex.Add('¦', @"{ \choose }");
            unicodeToLatex.Add('〖', @"(");
            unicodeToLatex.Add('〗', @")");
            unicodeToLatex.Add('┴', "text above");  //requires additional definitions
            unicodeToLatex.Add('┬', "text below");  //requires additional definitions
            unicodeToLatex.Add('┤', @"");
            unicodeToLatex.Add('≝', @"=");  //requires additional definitions
            unicodeToLatex.Add('≞', @"=");  //requires additional definitions
            unicodeToLatex.Add('{', @"\{");
            unicodeToLatex.Add('}', @"\}");
            unicodeToLatex.Add('〈', @"\langle ");
            unicodeToLatex.Add('〉', @"\rangle ");
            unicodeToLatex.Add('⌊', @"\lfloor ");
            unicodeToLatex.Add('⌋', @"\rfloor ");
            unicodeToLatex.Add('⌈', @"\lceil ");
            unicodeToLatex.Add('⌉', @"\rceil ");
            unicodeToLatex.Add('‖', @"\|");
            unicodeToLatex.Add('⟦', @"\lBrack ");   //fdsymbol package
            unicodeToLatex.Add('⟧', @"\rBrack ");   //fdsymbol package
            unicodeToLatex.Add('│', @"\vert ");   //fdsymbol package

            unicodeToLatex.Add('̇', @"\dot{}");
            unicodeToLatex.Add('̈', @"\ddot{}");
            unicodeToLatex.Add('⃛', @"\dddot{}");
            unicodeToLatex.Add('̂', @"\hat{}");
            unicodeToLatex.Add('̌', @"\check{}");
            unicodeToLatex.Add('́', @"\acute{}");
            unicodeToLatex.Add('̀', @"\grave{}");
            unicodeToLatex.Add('̆', @"\breve{}");
            unicodeToLatex.Add('̃', @"\tilde{}");
            unicodeToLatex.Add('̅', @"\bar{}");
            unicodeToLatex.Add('̿', @"\bar{\bar{}}");
            unicodeToLatex.Add('⏞', @"\overbrace{}");
            unicodeToLatex.Add('⏟', @"\brace{}");
            unicodeToLatex.Add('⃖', @"\overleftarrow{}");
            unicodeToLatex.Add('⃗', @"\vec{}");
            unicodeToLatex.Add('⃡', @"\overleftrightarrow{}");
            unicodeToLatex.Add('⃐', @"\overleftarrow{}");    //harpoon not supported
            unicodeToLatex.Add('⃑', @"\vec{}");    //harpoon not supported
            unicodeToLatex.Add('▭', @"");    //frame not supported - to frame the entire equation use framed package instead
            unicodeToLatex.Add('¯', @"\overline{}");
            unicodeToLatex.Add('▁', @"\underline{}");

            unicodeToLatex.Add('∅', @"\emptyset ");
            unicodeToLatex.Add('%', @"\% ");
            unicodeToLatex.Add('°', @"\degree ");   //gensymb package
            unicodeToLatex.Add('℉', @"^{\circ}F ");
            unicodeToLatex.Add('℃', @"^{\circ}C ");
            unicodeToLatex.Add('∆', @"\increment ");    //stix package
            unicodeToLatex.Add('∇', @"\nabla ");
            
            unicodeToLatex.Add('←', @"\leftarrow ");
            unicodeToLatex.Add('↑', @"\uparrow ");
            unicodeToLatex.Add('→', @"\rightarrow ");
            unicodeToLatex.Add('↓', @"\downarrow ");
            unicodeToLatex.Add('↔', @"\leftrightarrow ");
            unicodeToLatex.Add('↕', @"\updownarrow ");
            unicodeToLatex.Add('⇐', @"\Leftarrow ");
            unicodeToLatex.Add('⇒', @"\Rightarrow ");
            unicodeToLatex.Add('⇔', @"\Leftrightarrow ");
            unicodeToLatex.Add('⇕', @"\Updownarrow ");
            unicodeToLatex.Add('⟵', @"\longleftarrow ");
            unicodeToLatex.Add('⟶', @"\longrightarrow ");
            unicodeToLatex.Add('⟷', @"\longleftrightarrow ");
            unicodeToLatex.Add('⟸', @"\Longleftarrow ");
            unicodeToLatex.Add('⟹', @"\Longrightarrow ");
            unicodeToLatex.Add('⟺', @"\Longleftrightarrow ");
            unicodeToLatex.Add('↗', @"\nearrow ");
            unicodeToLatex.Add('↖', @"\nwarrow ");
            unicodeToLatex.Add('↘', @"\searrow ");
            unicodeToLatex.Add('↙', @"\swarrow ");
            unicodeToLatex.Add('↚', @"\nleftarrow ");   //amssymb package
            unicodeToLatex.Add('↛', @"\nrightarrow ");  //amssymb package
            unicodeToLatex.Add('↮', @"\nleftrightarrow ");  //amssymb package
            unicodeToLatex.Add('⇍', @"\nLeftarrow ");   //amssymb package
            unicodeToLatex.Add('⇏', @"\nRightarrow ");  //amssymb package
            unicodeToLatex.Add('⇎', @"\nLeftrightarrow ");  //amssymb package
            unicodeToLatex.Add('⇠', @"\dashleftarrow ");    //amssymb package
            unicodeToLatex.Add('⇢', @"\dashrightarrow ");   //amssymb package
            unicodeToLatex.Add('↤', @"\mapsfrom "); //fdsymbol package
            unicodeToLatex.Add('↦', @"\mapsto ");
            unicodeToLatex.Add('⟻', @"\longmapsfrom "); //fdsymbol package
            unicodeToLatex.Add('⟼', @"\longmapsto ");
            unicodeToLatex.Add('↩', @"\hookleftarrow ");
            unicodeToLatex.Add('↪', @"\hookrightarrow ");
            unicodeToLatex.Add('↼', @"\leftharpoonup ");
            unicodeToLatex.Add('↽', @"\leftharpoondown ");
            unicodeToLatex.Add('⇀', @"\rightharpoonup ");
            unicodeToLatex.Add('⇁', @"\rightharpoondown ");
            unicodeToLatex.Add('↿', @"\upharpoonleft ");    //amssymb package
            unicodeToLatex.Add('↾', @"\upharpoonright ");   //amssymb package
            unicodeToLatex.Add('⇃', @"\downharpoonleft ");  //amssymb package
            unicodeToLatex.Add('⇂', @"\downharpoonright "); //amssymb package
            unicodeToLatex.Add('⇋', @"\leftrightharpoons ");    //amssymb package
            unicodeToLatex.Add('⇌', @"\rightleftharpoons ");
            unicodeToLatex.Add('⇇', @"\leftleftarrows ");   //amssymb package
            unicodeToLatex.Add('⇉', @"\rightrightarrows "); //amssymb package
            unicodeToLatex.Add('⇈', @"\upuparrows ");   //amssymb package
            unicodeToLatex.Add('⇊', @"\downdownarrows ");   //amssymb package
            unicodeToLatex.Add('⇆', @"\leftrightarrows ");  //amssymb package
            unicodeToLatex.Add('⇄', @"\rightleftarrows ");  //amssymb package
            unicodeToLatex.Add('↫', @"\looparrowleft ");    //amssymb package
            unicodeToLatex.Add('↬', @"\looparrowright ");   //amssymb package
            unicodeToLatex.Add('↢', @"\leftarrowtail ");    //amssymb package
            unicodeToLatex.Add('↣', @"\rightarrowtail ");   //amssymb package
            unicodeToLatex.Add('↰', @"\Lsh ");  //amssymb package
            unicodeToLatex.Add('↱', @"\Rsh ");  //amssymb package
            unicodeToLatex.Add('↲', @"\Ldsh "); //fdsymbol package
            unicodeToLatex.Add('↳', @"\Rdsh "); //fdsymbol package
            unicodeToLatex.Add('⇚', @"\Lleftarrow ");   //amssymb package
            unicodeToLatex.Add('⇛', @"\Rrightarrow ");  //amssymb package
            unicodeToLatex.Add('↞', @"\twoheadleftarrow "); //amssymb package
            unicodeToLatex.Add('↠', @"\twoheadrightarrow ");    //amssymb package
            unicodeToLatex.Add('↶', @"\curvearrowleft ");   //amssymb package
            unicodeToLatex.Add('↷', @"\curvearrowright ");  //amssymb package
            unicodeToLatex.Add('↺', @"\circlearrowleft ");  //amssymb package
            unicodeToLatex.Add('↻', @"\circlearrowright "); //amssymb package
            unicodeToLatex.Add('⊸', @"\multimap "); //amssymb package
            unicodeToLatex.Add('↭', @"\leftrightwavearrow ");   //fdsymbol package
            unicodeToLatex.Add('↜', @"\leftwavearrow ");    //fdsymbol package
            unicodeToLatex.Add('↝', @"\rightwavearrow ");   //fdsymbol package
            unicodeToLatex.Add('⇜', @"\leftsquigarrow ");    //stix package
            unicodeToLatex.Add('⇝', @"\rightsquigarrow ");  //stix package

            unicodeToLatex.Add('⊈', @"\nsubseteq ");    //amssymb package
            unicodeToLatex.Add('⊉', @"\nsupseteq ");    //amssymb package
            unicodeToLatex.Add('⊊', @"\subsetneq ");    //amssymb package
            unicodeToLatex.Add('⊋', @"\supsetneq ");    //amssymb package
            unicodeToLatex.Add('⋢', @"\nsqsubseteq ");  //fdsymbol package
            unicodeToLatex.Add('⋣', @"\nsqsupseteq ");  //fdsymbol package
            unicodeToLatex.Add('⋦', @"\lnsim ");    //amssymb package
            unicodeToLatex.Add('⋧', @"\gnsim ");    //amssymb package
            unicodeToLatex.Add('⋨', @"\precnsim "); //amssymb package
            unicodeToLatex.Add('⋩', @"\succnsim "); //amssymb package
            unicodeToLatex.Add('⋪', @"\nlessclosed ");  //fdsymbol package
            unicodeToLatex.Add('⋫', @"\ngtrclosed ");   //fdsymbol package
            unicodeToLatex.Add('⋬', @"\nleqclosed ");   //fdsymbol package
            unicodeToLatex.Add('⋭', @"\ngeqclosed ");   //fdsymbol package
            unicodeToLatex.Add('∤', @"\nmid "); //amssymb package
            unicodeToLatex.Add('∦', @"\nparallel ");    //amssymb package
            unicodeToLatex.Add('⊬', @"\nvdash ");   //amssymb package
            unicodeToLatex.Add('⊭', @"\nvDash ");   //amssymb package
            unicodeToLatex.Add('⊮', @"\nrightVdash ");   //fdsymbol package
            unicodeToLatex.Add('⊯', @"\nrightVDash ");  //fdsymbol package
            unicodeToLatex.Add('≁', @"\nsim "); //amssymb package
            unicodeToLatex.Add('≭', @"\nasymp ");   //fdsymbol package
            unicodeToLatex.Add('≨', @"\lneqq ");    //amssymb package
            unicodeToLatex.Add('≩', @"\gneqq ");    //amssymb package
            unicodeToLatex.Add('⊀', @"\nprec ");    //amssymb package
            unicodeToLatex.Add('⊁', @"\nsucc ");    //amssymb package
            unicodeToLatex.Add('⋠', @"\npreccurlyeq "); //fdsymbol package
            unicodeToLatex.Add('⋡', @"\nsucccurlyeq "); //fdsymbol package
            unicodeToLatex.Add('∌', @"\notcontain ");
            unicodeToLatex.Add('⊄', @"\nsubset ");  //fdsymbol package
            unicodeToLatex.Add('⊅', @"\nsupset ");  //fdsymbol package

            unicodeToLatex.Add('¬', @"\neg ");

            unicodeToLatex.Add('α', @"\alpha ");
            unicodeToLatex.Add('β', @"\beta ");
            unicodeToLatex.Add('γ', @"\gamma ");
            unicodeToLatex.Add('δ', @"\delta ");
            unicodeToLatex.Add('ε', @"\varepsilon ");
            unicodeToLatex.Add('ϵ', @"\epsilon ");
            unicodeToLatex.Add('ζ', @"\zeta ");
            unicodeToLatex.Add('η', @"\eta ");
            unicodeToLatex.Add('θ', @"\theta ");
            unicodeToLatex.Add('ϑ', @"\vartheta ");
            unicodeToLatex.Add('ι', @"\iota ");
            unicodeToLatex.Add('κ', @"\kappa ");
            unicodeToLatex.Add('λ', @"\lambda ");
            unicodeToLatex.Add('μ', @"\mu ");
            unicodeToLatex.Add('ν', @"\nu ");
            unicodeToLatex.Add('ξ', @"\xi ");
            unicodeToLatex.Add('ο', @"o");
            unicodeToLatex.Add('π', @"\pi ");
            unicodeToLatex.Add('ϖ', @"\varpi ");
            unicodeToLatex.Add('ρ', @"\rho ");
            unicodeToLatex.Add('ϱ', @"\varrho ");
            unicodeToLatex.Add('σ', @"\sigma ");
            unicodeToLatex.Add('ς', @"\varsigma ");
            unicodeToLatex.Add('τ', @"\tau ");
            unicodeToLatex.Add('υ', @"\upsilon ");
            unicodeToLatex.Add('ϕ', @"\phi ");
            unicodeToLatex.Add('φ', @"\varphi ");
            unicodeToLatex.Add('χ', @"\chi ");
            unicodeToLatex.Add('ψ', @"\psi ");
            unicodeToLatex.Add('ω', @"\omega ");

            unicodeToLatex.Add('Α', @"A");
            unicodeToLatex.Add('Β', @"B");
            unicodeToLatex.Add('Γ', @"\Gamma ");
            unicodeToLatex.Add('Δ', @"\Delta ");
            unicodeToLatex.Add('Ε', @"E");
            unicodeToLatex.Add('Ζ', @"Z");
            unicodeToLatex.Add('Η', @"H");
            unicodeToLatex.Add('Θ', @"\Theta ");
            unicodeToLatex.Add('Ι', @"I");
            unicodeToLatex.Add('Κ', @"K");
            unicodeToLatex.Add('Λ', @"\Lambda ");
            unicodeToLatex.Add('Μ', @"M");
            unicodeToLatex.Add('Ν', @"N");
            unicodeToLatex.Add('Ξ', @"\Xi ");
            unicodeToLatex.Add('Ο', @"O");
            unicodeToLatex.Add('Π', @"\Pi ");
            unicodeToLatex.Add('Ρ', @"P");
            unicodeToLatex.Add('Σ', @"\Sigma ");
            unicodeToLatex.Add('Τ', @"T");
            unicodeToLatex.Add('Υ', @"\Upsilon ");
            unicodeToLatex.Add('Φ', @"\Phi ");
            unicodeToLatex.Add('Χ', @"X");
            unicodeToLatex.Add('Ψ', @"\Psi ");
            unicodeToLatex.Add('Ω', @"\Omega ");

            unicodeToLatex.Add('·', @"\cdot ");
            unicodeToLatex.Add('⋮', @"\vdots ");
            unicodeToLatex.Add('⋯', @"\cdots ");
            unicodeToLatex.Add('⋰', @"\udots ");    //fdsymbol package
            unicodeToLatex.Add('⋱', @"\ddots ");
            unicodeToLatex.Add('∎', @"\blacksquare ");   //amssymb package
            unicodeToLatex.Add('∟', @"\rightangle ");   //fdsymbol package
            unicodeToLatex.Add('∠', @"\angle ");
            unicodeToLatex.Add('∡', @"\measuredangle ");    //amssymb package
            unicodeToLatex.Add('∢', @"\sphericalangle ");   //amssymb package
            unicodeToLatex.Add('⊾', @"\measuredrightangle ");   //fdsymbol package
            unicodeToLatex.Add('⊿', @"\varlrtriangle ");    //stix package
            unicodeToLatex.Add('⋕', @"\equalparallel"); //stix package
            unicodeToLatex.Add('∶', @"\ratio ");    //colonequals package
            unicodeToLatex.Add('∷', @"\squaredots "); //fdsymbol package

        }
    }
}
